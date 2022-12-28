namespace PrimeDrive.Realizations.Domain;

using Locations;
using Prices;
using Rides;

public sealed class Realization : Entity, IAggregateRoot
{
    private Realization(
        ServiceRequestId serviceId,
        DriverId driver,
        Location pickupPoint,
        Location destinationPoint)
    {
    }

    public RealizationId Id { get; private set; }
    private ServiceRequestId ServiceId { get; set; }
    private RealizationStatus Status { get; set; }

    private Money Price { get; }
    private DriverId DriverId { get; set; }
    private IList<Ride> Rides { get; }

    public static Realization Begin(
        ServiceRequestId serviceId,
        DriverId driver,
        Location pickupPoint,
        Location destinationPoint) =>
        new(serviceId, driver, pickupPoint, destinationPoint);

    public void AddStopPoint(Location location)
    {
    }

    public void FinishRide(Location carLocation)
    {
    }

    public void BeginNewRide(Location startPoint,
        Location destinationPoint)
    {
    }
    
    private bool RealizationInProgress { get; }

    public void Cancel()
    {
    }

    public void Complete()
    {
    }
}