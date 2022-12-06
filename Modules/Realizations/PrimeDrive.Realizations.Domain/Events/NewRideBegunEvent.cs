namespace PrimeDrive.Realizations.Domain.Events;

using Rides;

public record NewRideBegunEvent(
    RealizationId RealizationId, RideId RideId) : DomainEventBase;
