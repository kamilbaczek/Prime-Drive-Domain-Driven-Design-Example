using PrimeDrive.DomainDrivenDesign.BuildingBlocks.Blocks;

namespace PrimeDrive.Realizations.Domain;

public sealed class Realization : Entity, IAggregateRoot
{
    public Guid Id { get; private set; }
    public Guid ServiceId { get; private set; }
    public string PickupPoint { get; private set; }
    public string DestinationPoint { get; private set; }
    public string DriverName { get; private set; }
    public decimal Price { get; private set; }
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