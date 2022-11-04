using PrimeDrive.DomainDrivenDesign.BuildingBlocks.Blocks;
using PrimeDrive.Realizations.Domain.Locations;
using PrimeDrive.Realizations.Domain.Prices;
using PrimeDrive.Realizations.Domain.Rides.Stops;

namespace PrimeDrive.Realizations.Domain.Rides;

public sealed class Ride : Entity
{
    public Ride(Stop pickupPoint, Stop destinationPoint)
    {
        Stops = new LinkedList<Stop>();
        Stops.AddFirst(pickupPoint);
        Stops.AddLast(destinationPoint);
    }

    public void AddStop(Location location)
    {
        var stop = new Stop();
        Stops.AddBefore(Stops.Last!, stop);
    }

    private LinkedList<Stop> Stops {get;}

    public Price Price { get; private set; }
    private Stop PickupPoint => Stops.First();
    private Stop DestinationPoint => Stops.Last();
}