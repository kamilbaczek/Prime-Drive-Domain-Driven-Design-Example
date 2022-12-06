namespace PrimeDrive.Realizations.Domain.Rides;

using DomainDrivenDesign.BuildingBlocks.Blocks;
using Exceptions;
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
        RideStatus = RideStatus.InProgress;
    }

    private Stop PickupPoint { get; }
    private Stop DestinationPoint { get; }

    private LinkedList<Stop> AdditionalStops { get; }
    private RideStatus RideStatus { get; set; }
    internal int AdditionalStopsCount => AdditionalStops.Count;
    internal bool IsInprogress => RideStatus == RideStatus.InProgress;

    internal RideId Id { get; }
    internal Money Price { get; }

    internal static Ride Begin(Location pickupPoint, Location destinationPoint) => 
        new(pickupPoint, destinationPoint);

    internal void AddStop(Location location)
    {
        var stop = Stop.Create(location);
        AdditionalStops.AddFirst(stop);
    }

    internal void Finish(Location carLocation)
    {
        var destinationStop = DestinationPoint.Location;
        if (carLocation != destinationStop)
            throw new CarIsNotOnDestinationPointException(carLocation, destinationStop);

        RideStatus = RideStatus.Finished;
    }

    internal void Cancel() => 
        RideStatus = RideStatus.Canceled;
}