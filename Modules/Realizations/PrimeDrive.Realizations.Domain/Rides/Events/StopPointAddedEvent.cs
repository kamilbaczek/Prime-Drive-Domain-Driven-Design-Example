namespace PrimeDrive.Realizations.Domain.Rides.Events;

using Locations;

public record StopPointAddedEvent(RideId RideId, Location Location) : DomainEventBase;
