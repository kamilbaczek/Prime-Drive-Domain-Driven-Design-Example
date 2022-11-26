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
        AdditionalStops = new LinkedList<Stop>();
        var pickupStop = Stop.Create(pickupPoint);
        var destinationStop = Stop.Create(destinationPoint);
        PickupPoint = pickupStop;
        DestinationPoint = destinationStop;
        Price = Money.From(Currency.Usd, RideCost);
    }

    private Stop PickupPoint { get; }
    private Stop DestinationPoint { get; }

    private LinkedList<Stop> AdditionalStops { get; }
    internal int AdditionalStopsCount => AdditionalStops.Count;

    private List<Stop> Stops()
    {
        var stops = new List<Stop>
        {
            PickupPoint
        };
        stops.AddRange(AdditionalStops);
        stops.Add(DestinationPoint);

        return stops;
    }

    internal RideId Id { get; }
    internal Money Price { get; }

    internal static Ride Begin(Location pickupPoint, Location destinationPoint) =>
        new(pickupPoint, destinationPoint);

    internal void AddStop(Location location)
    {
        var stop = Stop.Create(location);
        AdditionalStops.AddFirst(stop);
    }
}
