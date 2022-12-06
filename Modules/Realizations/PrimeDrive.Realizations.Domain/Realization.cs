namespace PrimeDrive.Realizations.Domain;

using Events;
using Exceptions;
using Locations;
using Prices;
using Rides;
using Rides.Events;
using Rides.Extensions;
using Rides.Stops.Policy;

public sealed class Realization : Entity, IAggregateRoot
{
    private Realization(
        ServiceRequestId serviceId,
        DriverId driver,
        Location pickupPoint,
        Location destinationPoint)
    {
        Id = RealizationId.New();
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

    private Money Price => Rides.Calculate();
    private DriverId DriverId { get; set; }
    private IList<Ride> Rides { get; }

    public static Realization Begin(
        ServiceRequestId serviceId,
        DriverId driver,
        Location pickupPoint,
        Location destinationPoint) =>
        new(serviceId, driver, pickupPoint, destinationPoint);

    public void AddStopPoint(Location location)
    {
        if (!RealizationInProgress)
            throw new RealizationAlreadyCompletedException(Status);

        var ride = Rides.GetInprogress();
        var policy = new AdditionalStopsPerRideLimitPolicy(ride!.AdditionalStopsCount);
        policy.Validate();

        ride.AddStop(location);

        var @event = new StopPointAddedEvent(ride.Id, location);
        AddDomainEvent(@event);
    }

    public void FinishRide(Location carLocation)
    {
        if (!RealizationInProgress)
            throw new RealizationAlreadyCompletedException(Status);
        var ride = Rides.GetInprogress();

        ride!.Finish(carLocation);

        var @event = new RideFinishedEvent(Id, ride.Id);
        AddDomainEvent(@event);
    }

    public void BeginNewRide(Location startPoint,
        Location destinationPoint)
    {
        if (!RealizationInProgress)
            throw new RealizationAlreadyCompletedException(Status);

        var ride = Rides.GetInprogress();
        if (ride is not null)
            throw new RideIsInprogressException();

        var newRide = Ride.Begin(startPoint, destinationPoint);
        Rides.Add(newRide);
        var @event = new NewRideBegunEvent(Id, newRide.Id);
        AddDomainEvent(@event);
    }
    private bool RealizationInProgress => Status == RealizationStatus.InProgress;

    public void Cancel()
    {
        if (!RealizationInProgress)
            throw new RealizationAlreadyCompletedException(Status);

        Status = RealizationStatus.Canceled;
        var ride = Rides.GetInprogress();
        ride!.Cancel();
        var @event = new RealizationCancelledEvent(Id);
        AddDomainEvent(@event);
    }

    public void Complete()
    {
        var ride = Rides.GetInprogress();
        if (ride is not null)
            throw new RideIsInprogressException();

        Status = RealizationStatus.Completed;
        var @event = new RealizationCompletedEvent(Id, Price);
        AddDomainEvent(@event);
    }
}