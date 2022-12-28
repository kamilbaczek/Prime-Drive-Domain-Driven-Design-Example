namespace PrimeDrive.Realizations.Domain.Rides;

using Locations;
using Prices;
using Stops;

public sealed class Ride : Entity
{
    private Ride(Location pickupPoint, Location destinationPoint)
    {
    }

    private Stop PickupPoint { get; }
    private Stop DestinationPoint { get; }

    private LinkedList<Stop> AdditionalStops { get; }
    private RideStatus RideStatus { get; set; }
    internal int AdditionalStopsCount => AdditionalStops.Count;
    internal bool IsInprogress { get; }

    internal RideId Id { get; }
    internal Money Price { get; }

    internal static Ride Begin(Location pickupPoint, Location destinationPoint) => 
        new(pickupPoint, destinationPoint);

    internal void AddStop(Location location)
    {
    }

    internal void Finish(Location carLocation)
    {
    }

    internal void Cancel()
    {
        
    }
}