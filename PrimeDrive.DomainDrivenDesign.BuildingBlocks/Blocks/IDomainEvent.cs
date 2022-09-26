namespace PrimeDrive.DomainDrivenDesign.BuildingBlocks.Blocks;

using MediatR;

public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccurredOn { get; }
}