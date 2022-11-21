using PrimeDrive.DomainDrivenDesign.BuildingBlocks.Blocks;
using PrimeDrive.Realizations.Domain.Locations;
using PrimeDrive.Realizations.Domain.Prices;
using PrimeDrive.Realizations.Domain.Rides.Stops;

namespace PrimeDrive.Realizations.Domain.Rides;

public sealed class Ride : Entity
{
    private const int RideCost = 10;

    private Ride(Location pickupPoint, Location destinationPoint)
    {
        Id = RideId.Create();
        Stops = new LinkedList<Stop>();
        var pickupStop = Stop.Create(pickupPoint);
        var destinationStop = Stop.Create(destinationPoint);
        Stops.AddFirst(pickupStop);
        Stops.AddLast(destinationStop);
        Price = Money.From(Currency.Usd, RideCost);
    }

    internal static Ride Begin(Location pickupPoint, Location destinationPoint) => new(pickupPoint, destinationPoint);

    internal void AddStop(Location location)
    {
        var stop = Stop.Create(location);
        Stops.AddBefore(Stops.Last!, stop);
    }

    private LinkedList<Stop> Stops { get; }
    internal RideId Id { get; private set; }
    internal Money Price { get; private set; }
}