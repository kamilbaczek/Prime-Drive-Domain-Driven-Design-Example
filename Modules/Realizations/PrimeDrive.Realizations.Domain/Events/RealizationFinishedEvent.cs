namespace PrimeDrive.Realizations.Domain.Events;

using DomainDrivenDesign.BuildingBlocks.Blocks;
using Prices;

public record RealizationFinishedEvent(
    RealizationId RealizationId,
    Money Price) : DomainEventBase;