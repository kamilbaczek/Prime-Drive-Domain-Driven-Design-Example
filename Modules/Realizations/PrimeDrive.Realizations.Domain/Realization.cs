using PrimeDrive.DomainDrivenDesign.BuildingBlocks.Blocks;
using PrimeDrive.Realizations.Domain.Locations;
using PrimeDrive.Realizations.Domain.Rides;

namespace PrimeDrive.Realizations.Domain;

using Events;
using Prices;
using Rides.Extensions;

public sealed class Realization : Entity, IAggregateRoot
{
    public RealizationId Id { get; private set; }
    public ServiceRequestId ServiceId { get; private set; }

    // TODO extend Money Value object to have
    public Money Price => CalculateRidesPrice();
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

    private DriverId DriverId { get; set; }
    private IList<Ride> Rides { get; set; }

    private Realization(
        Location pickupPoint, 
        Location destinationPoint)
    {
        Rides = new List<Ride>();
        var initialRide = Ride.Begin(pickupPoint, destinationPoint);
        Rides.Add(initialRide);
        var @event = new RealizationBegunEvent();
        AddDomainEvent(@event);
    }

    public static Realization Begin(
        Location pickupPoint, 
        Location destinationPoint) => 
        new(pickupPoint, destinationPoint);

    public void AddStopPoint(Location location, RideId rideId)
    {
        var currentRide = Rides.Get(rideId);
        currentRide.AddStop(location);
        var @event = new StopPointAddedEvent();
        AddDomainEvent(@event);
    }

    public void Cancel()
    {
        //TODO Create valueobject named status with Ride sta
    }

    public void Complete()
    {
    }
}