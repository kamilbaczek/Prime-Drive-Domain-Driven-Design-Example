namespace PrimeDrive.DomainDrivenDesign.BuildingBlocks;

using Blocks;

public abstract class DomainEventBase : IDomainEvent
{
    protected DomainEventBase()
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
    }

    public Guid Id { get; }

    public DateTime OccurredOn { get; }
}