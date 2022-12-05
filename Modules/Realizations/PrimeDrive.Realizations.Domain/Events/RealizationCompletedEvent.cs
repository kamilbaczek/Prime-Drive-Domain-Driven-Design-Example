namespace PrimeDrive.Realizations.Domain.Events;

using DomainDrivenDesign.BuildingBlocks.Blocks;
using Prices;

public record RealizationCompletedEvent(
    RealizationId RealizationId,
    Money Price) : DomainEventBase;