using PrimeDrive.DomainDrivenDesign.BuildingBlocks.Blocks;
using PrimeDrive.Realizations.Domain.Locations;

namespace PrimeDrive.Realizations.Domain;

using Prices;

public sealed class Realization : Entity, IAggregateRoot
{
    public RealizationId Id { get; private set; }
    public ServiceRequestId ServiceId { get; private set; }
    public Location PickupPoint { get; private set; }
    public Location DestinationPoint { get; private set; }
    private DriverId DriverId { get; set; }
    public Price Price { get; private set; }
    public IList<Ride> StopPoints { get; private set; }

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
}

public sealed class StopPoint : Entity
{
}