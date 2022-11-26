namespace PrimeDrive.Realizations.Domain.Rides.Events;

using DomainDrivenDesign.BuildingBlocks.Blocks;
using Locations;

public record StopPointAddedEvent(RideId RideId, Location Location) : DomainEventBase;
