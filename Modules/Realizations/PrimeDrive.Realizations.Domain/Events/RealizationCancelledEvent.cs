namespace PrimeDrive.Realizations.Domain.Events;

using DomainDrivenDesign.BuildingBlocks.Blocks;

public record RealizationCancelledEvent(
    RealizationId RealizationId) : DomainEventBase;