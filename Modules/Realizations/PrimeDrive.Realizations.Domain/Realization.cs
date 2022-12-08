namespace PrimeDrive.Realizations.Domain;

using Events;
using Locations;
using Prices;
using Rides;
using Rides.Events;
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

        var @event = RealizationBegunEvent.Create(
            Id,
            ServiceId,
            initialRide.Id,
            DriverId,
            pickupPoint,
            destinationPoint);
        AddDomainEvent(@event);
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
        //TODO: add stop point cannot be added when there is realization already completed - policy

        var ride = Rides.GetInprogress();
        //TODO: add additional stops limit - policy

        ride.AddStop(location);

        var @event = new StopPointAddedEvent(ride.Id, location);
        AddDomainEvent(@event);
    }

    public void FinishRide(Location carLocation)
    {
        //TODO: add cannot cancel realization when there is ride in progress already - policy
        var ride = Rides.GetInprogress();

        ride!.Finish(carLocation);

        var @event = new RideFinishedEvent(Id, ride.Id);
        AddDomainEvent(@event);
    }

    public void BeginNewRide(Location startPoint,
        Location destinationPoint)
    {
        //TODO: add begin new ride cannot be executed when realization is already completed - policy

        var ride = Rides.GetInprogress();
        //TODO: begin new ride cannot be executed when there is ride in progress - policy
        
        var newRide = Ride.Begin(startPoint, destinationPoint);
        Rides.Add(newRide);
        var @event = new NewRideBegunEvent(Id, newRide.Id);
        AddDomainEvent(@event);
    }
    private bool RealizationInProgress => Status == RealizationStatus.InProgress;

    public void Cancel()
    {
        //TODO: add cannot cancel realization when there is ride in progress - policy
        
        Status = RealizationStatus.Canceled;
        var ride = Rides.GetInprogress();
        ride!.Cancel();
        var @event = new RealizationCancelledEvent(Id);
        AddDomainEvent(@event);
    }

    public void Complete()
    {
        var ride = Rides.GetInprogress();
        //TODO: add cannot complete realization when there is ride in progress - policy
        
        Status = RealizationStatus.Completed;
        var @event = new RealizationCompletedEvent(Id, Price);
        AddDomainEvent(@event);
    }
}