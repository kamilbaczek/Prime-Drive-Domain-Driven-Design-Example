namespace PrimeDrive.DomainDrivenDesign.BuildingBlocks.Blocks;

public abstract record DomainEventBase : IDomainEvent
{
    public Guid Id { get; }

    public DateTime OccurredOn { get; }
}
