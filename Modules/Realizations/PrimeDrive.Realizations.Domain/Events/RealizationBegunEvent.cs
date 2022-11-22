namespace PrimeDrive.Realizations.Domain.Events;

using DomainDrivenDesign.BuildingBlocks.Blocks;

public record RealizationBegunEvent: IDomainEvent
{
    public Guid Id { get; }
    public DateTime OccurredOn { get; }
}