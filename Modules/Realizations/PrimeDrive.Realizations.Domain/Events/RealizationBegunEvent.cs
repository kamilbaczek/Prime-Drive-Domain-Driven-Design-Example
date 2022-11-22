namespace PrimeDrive.Realizations.Domain.Events;

using DomainDrivenDesign.BuildingBlocks.Blocks;
using Locations;
using Rides;

public record RealizationBegunEvent(
    RealizationId RealizationId,
    RideId RideId,
    Location PickupPoint,
    Location DestinationPoint) : DomainEventBase;