namespace PrimeDrive.Realizations.Domain.Rides;

using DomainDrivenDesign.BuildingBlocks.Blocks;
using Locations;
using Prices;
using Stops;

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

    private LinkedList<Stop> Stops { get; }
    internal RideId Id { get; }
    internal Money Price { get; }

    internal static Ride Begin(Location pickupPoint, Location destinationPoint)
    {
        return new(pickupPoint, destinationPoint);
    }

    internal void AddStop(Location location)
    {
        var stop = Stop.Create(location);
        Stops.AddBefore(Stops.Last!, stop);
    }
}