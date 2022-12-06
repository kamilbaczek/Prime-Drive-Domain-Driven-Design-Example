namespace PrimeDrive.Realizations.Domain.Events;

using Prices;

public record RealizationCompletedEvent(
    RealizationId RealizationId,
    Money Price) : DomainEventBase;
