namespace PrimeDrive.Realizations.Domain;

using Locations;
using Prices;
using Rides;
using Rides.Extensions;

public sealed class Realization : Entity, IAggregateRoot
{
    private Realization(
        ServiceRequestId serviceId,
        DriverId driver,
        Location pickupPoint,
        Location destinationPoint)
    {
        Id = RealizationId.New();
        DriverId = driver;
        ServiceId = serviceId;
        Rides = new List<Ride>();
        Status = RealizationStatus.InProgress;
        var initialRide = Ride.Begin(pickupPoint, destinationPoint);
        Rides.Add(initialRide);
        //TODO: add domain event
    }

    public RealizationId Id { get; private set; }
    private ServiceRequestId ServiceId { get; set; }
    private RealizationStatus Status { get; set; }

    private Money Price => Rides.Calculate();
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
        var ride = Rides.GetInprogress();

        ride.AddStop(location);

        //TODO: add domain event
    }

    public void FinishRide(Location carLocation)
    {
        var ride = Rides.GetInprogress();

        ride!.Finish(carLocation);

        //TODO: add domain event
    }

    public void BeginNewRide(Location startPoint,
        Location destinationPoint)
    {
        var ride = Rides.GetInprogress();
        var newRide = Ride.Begin(startPoint, destinationPoint);
        Rides.Add(newRide);
        //TODO: add domain event
    }
    private bool RealizationInProgress => Status == RealizationStatus.InProgress;

    public void Cancel()
    {
        Status = RealizationStatus.Canceled;
        var ride = Rides.GetInprogress();
        ride!.Cancel();
        
        //TODO: add domain event
    }

    public void Complete()
    {
        var ride = Rides.GetInprogress();
        
        Status = RealizationStatus.Completed;
        //TODO: add domain event
    }
}