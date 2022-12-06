namespace PrimeDrive.Realizations.Domain.Events;

public record RealizationCancelledEvent(
    RealizationId RealizationId) : DomainEventBase;
