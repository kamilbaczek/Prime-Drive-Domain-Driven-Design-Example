namespace PrimeDrive.Realizations.Domain.Events;

using DomainDrivenDesign.BuildingBlocks.Blocks;
using Rides;

public record NewRideBegunEvent(
    RealizationId RealizationId, RideId RideId) : DomainEventBase;
