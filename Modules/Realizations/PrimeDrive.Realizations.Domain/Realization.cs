using PrimeDrive.DomainDrivenDesign.BuildingBlocks.Blocks;

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

    private Realization()
    {
    }

    public static Realization Begin => new Realization();

    public void AddStopPoint()
    {
    }

    public void Cancel()
    {
    }

    public void Complete()
    {
    }
}

public sealed class Ride : Entity
{
    public Ride(Stop pickupPoint, Stop destinationPoint)
    {
        Stops = Array.Empty<Stop>().ToList();
        Stops.Add(pickupPoint);
        Stops.Add(destinationPoint);
    }
    private List<Stop> Stops {get;}

    public Price Price { get; private set; }
    private Stop PickupPoint => Stops.First();
    private Stop DestinationPoint => Stops.Last();
}

public sealed class Stop : Entity
{
}