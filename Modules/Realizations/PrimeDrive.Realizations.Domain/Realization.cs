namespace PrimeDrive.Realizations.Domain;

using DomainDrivenDesign.BuildingBlocks.Blocks;
using Events;
using Locations;
using Prices;
using Rides;
using Rides.Events;
using Rides.Extensions;
using Rides.Stops;

public sealed class Realization : Entity, IAggregateRoot
{
    private Realization(
        ServiceRequestId serviceId,
        DriverId driver,
        Location pickupPoint,
        Location destinationPoint)
    {
        DriverId = driver;
        ServiceId = serviceId;
        Rides = new List<Ride>();
        Status = RealizationStatus.InProgress;
        var initialRide = Ride.Begin(pickupPoint, destinationPoint);
        Rides.Add(initialRide);

        var @event = RealizationBegunEvent.Create(
            Id,
            ServiceId,
            initialRide.Id,
            DriverId,
            pickupPoint,
            destinationPoint);
        AddDomainEvent(@event);
    }

    public RealizationId Id { get; private set; }
    private ServiceRequestId ServiceId { get; set; }
    private RealizationStatus Status { get; set; }

    private Money Price => DiscountCalculator.CalculateRidesPrice(Rides);
    private DriverId DriverId { get; set; }
    private IList<Ride> Rides { get; }

    public static Realization Begin(
        ServiceRequestId serviceId,
        DriverId driver,
        Location pickupPoint,
        Location destinationPoint) =>
        new(serviceId, driver, pickupPoint, destinationPoint);

    public void AddStopPoint(RideId rideId, Location location)
    {
        var currentRide = Rides.Get(rideId);
        var policy = new AdditionalStopsPerRideLimitPolicy(currentRide.AdditionalStopsCount);
        policy.Guard();

        currentRide.AddStop(location);

        var @event = new StopPointAddedEvent(rideId, location);
        AddDomainEvent(@event);
    }

    public void Cancel()
    {
        Status = RealizationStatus.Canceled;
        var @event = new RealizationCancelledEvent(Id);
        AddDomainEvent(@event);
    }

    public void Complete()
    {
        Status = RealizationStatus.Completed;
        var @event = new RealizationFinishedEvent(Id, Price);
        AddDomainEvent(@event);
    }
}