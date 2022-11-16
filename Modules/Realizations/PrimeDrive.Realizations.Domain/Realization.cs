using PrimeDrive.DomainDrivenDesign.BuildingBlocks.Blocks;
using PrimeDrive.Realizations.Domain.Locations;
using PrimeDrive.Realizations.Domain.Rides;

namespace PrimeDrive.Realizations.Domain;

using Prices;

public sealed class Realization : Entity, IAggregateRoot
{
    public RealizationId Id { get; private set; }
    public ServiceRequestId ServiceId { get; private set; }

    // TODO extend Price Value object to have
    public Price Price {get;}

    private DriverId DriverId { get; set; }
    public IList<Ride> Rides { get; private set; }

    private Realization(Location pickupPoint, Location destinationPoint)
    {
        Rides = new List<Ride>();
        var intialRide = Ride.Begin(pickupPoint, destinationPoint);
        Rides.Add(intialRide);
    }

    public static Realization Begin(Location pickupPoint, Location destinationPoint) => new (pickupPoint, destinationPoint);

    public void AddStopPoint(Location location, RideId rideId)
    {
        //TODO update event storming map to handle case when "More than one ride then 50% discount for second one"
        //TODO create extension method from IList<Ride> Get(rideId)
        var currentRide = Rides.Single(ride => ride.Id == rideId);
        currentRide.AddStop(location);
        // Add Domain event
    }

    public void Cancel()
    {
        //TODO Create valueobject named status with Ride sta
    }

    public void Complete()
    {
    }
}

