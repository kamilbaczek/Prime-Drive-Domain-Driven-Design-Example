namespace PrimeDrive.Realizations.Domain.Tests;

using Events;
using Exceptions;
using Extensions;
using Extensions.Assertions.RideFinished;
using Fakers;
using Fakers.Builder;
using Rides.Exceptions;

public class FinishRideTests
{
    [Test]
    public void Given_FinishRide_When_RideIsInprogressAndCarIsAtDestinationLocation_Then_RideWasFinished()
    {
        Realization realization = A
            .Realization()
            .WithRide();
        var realizationBegunEvent = realization.DomainEvents.GetEvent<RealizationBegunEvent>();

        realization.FinishRide(realizationBegunEvent.DestinationPoint);

        var rideFinishedEvent = realization.DomainEvents.GetEvent<RideFinishedEvent>();
        //TODO write assertions rideFinishedEvent
        rideFinishedEvent.Should().NotBeNull();
    }

    [Test]
    public void Given_FinishRide_When_RideIsNotInprogress_Then_ThrowRealizationHasToBeInprogressException()
    {
        Realization realization = A
            .Realization()
            .WithRide()
            .WithFinished()
            .WithCompleted();
        var realizationBegunEvent = realization.DomainEvents.GetEvent<RealizationBegunEvent>();

        var action = () => realization.FinishRide(realizationBegunEvent.DestinationPoint);

        action.Should().ThrowExactly<RealizationAlreadyCompletedException>();
    }

    [Test]
    public void Given_FinishRide_When_CarIsNotAtDestinationLocation_Then_ThrowCarIsNotOnDestinationPointException()
    {
        Realization realization = A
            .Realization()
            .WithRide();
        var location = LocationRandomizer.GetRandom();

        var action = () => realization.FinishRide(location);

        action.Should().ThrowExactly<CarIsNotOnDestinationPointException>();
    }
}