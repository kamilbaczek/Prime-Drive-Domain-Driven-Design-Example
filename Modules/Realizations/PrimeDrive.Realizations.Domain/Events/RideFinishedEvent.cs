namespace PrimeDrive.Realizations.Domain.Events;

using DomainDrivenDesign.BuildingBlocks.Blocks;
using Rides;

public record RideFinishedEvent(
    RealizationId RealizationId, RideId RideId) : DomainEventBase;
