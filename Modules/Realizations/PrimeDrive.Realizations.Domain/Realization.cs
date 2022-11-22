namespace PrimeDrive.Realizations.Domain;

using DomainDrivenDesign.BuildingBlocks.Blocks;
using Events;
using Locations;
using Prices;
using Rides;
using Rides.Events;
using Rides.Extensions;

public sealed class Realization : Entity, IAggregateRoot
{
    private string State = "";

    private Realization(
        Location pickupPoint,
        Location destinationPoint)
    {
        Rides = ImmutableList<Ride>.Empty;

        var initialRide = Ride.Begin(pickupPoint, destinationPoint);
        Rides.Add(initialRide);

        var @event = new RealizationBegunEvent(Id, initialRide.Id, pickupPoint, destinationPoint);
        AddDomainEvent(@event);
    }
    public RealizationId Id { get; private set; }
    public ServiceRequestId ServiceId { get; private set; }

    public Money Price => CalculateRidesPrice();

    private DriverId DriverId { get; set; }
    private IList<Ride> Rides { get; }
    private Money CalculateRidesPrice()
    {
        var finalPrice = Money.Zero(Currency.Usd);
        for (var rideNumber = 1; rideNumber <= Rides.Count; rideNumber++)
        {
            if (rideNumber > 1)
            {
                finalPrice += Rides[rideNumber]
                    .Price
                    .WithHalfDiscount();
                continue;
            }

            finalPrice += Rides[rideNumber].Price;
        }

        return finalPrice;
    }

    public static Realization Begin(
        Location pickupPoint,
        Location destinationPoint) =>
        new(pickupPoint, destinationPoint);

    public void AddStopPoint(RideId rideId, Location location)
    {
        var currentRide = Rides.Get(rideId);

        currentRide.AddStop(location);

        var @event = new StopPointAddedEvent(rideId, location);
        AddDomainEvent(@event);
    }

    public void Cancel()
    {
        var @event = new RealizationCancelledEvent(Id);
        AddDomainEvent(@event);
    }

    public void Complete()
    {
        var @event = new RealizationFinishedEvent(Id, Price);
        AddDomainEvent(@event);
    }
}