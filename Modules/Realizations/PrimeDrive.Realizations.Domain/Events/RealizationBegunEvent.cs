namespace PrimeDrive.Realizations.Domain.Events;

using DomainDrivenDesign.BuildingBlocks.Blocks;
using Locations;
using Rides;

public record RealizationBegunEvent(
    RealizationId RealizationId,
    ServiceRequestId ServiceRequestId,
    RideId RideId,
    DriverId DriverId,
    Location PickupPoint,
    Location DestinationPoint) : DomainEventBase
{
    internal static RealizationBegunEvent Create(
        RealizationId realizationId,
        ServiceRequestId serviceRequestId,
        RideId rideId,
        DriverId driverId,
        Location pickupPoint,
        Location destinationPoint)
    {
        return new RealizationBegunEvent(
            realizationId,
            serviceRequestId,
            rideId,
            driverId,
            pickupPoint,
            destinationPoint);
    }
}
