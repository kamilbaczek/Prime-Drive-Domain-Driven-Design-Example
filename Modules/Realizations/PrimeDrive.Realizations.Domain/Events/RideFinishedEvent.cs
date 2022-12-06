namespace PrimeDrive.Realizations.Domain.Events;

using Rides;

public record RideFinishedEvent(
    RealizationId RealizationId, RideId RideId) : DomainEventBase;
