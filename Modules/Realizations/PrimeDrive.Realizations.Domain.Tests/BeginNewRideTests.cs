namespace PrimeDrive.Realizations.Domain.Tests;

using Events;
using Exceptions;
using Extensions;
using Fakers;
using Fakers.Builder;

public class BeginNewRideTests
{
    [Test]
    public void Given_BeginNewRide_When_NoInprogressRidesAndRealizationIsNotCompletedOrCancelled_Then_NewRideBegun()
    {
        Realization realization = A.Realization()
            .WithRide()
            .WithFinished();
        var startPoint = LocationRandomizer.GetRandom();
        var destinationPoint = LocationRandomizer.GetRandom();

        realization.BeginNewRide(startPoint, destinationPoint);

        var newRideBegunEvent = realization.DomainEvents.GetEvent<NewRideBegunEvent>();
        newRideBegunEvent.Should().NotBeNull();
    }
    
    [Test]
    public void Given_BeginNewRide_When_RideIsAlreadyInprogress_Then_CannotBeginNewRide()
    {
        Realization realization = A.Realization()
            .WithRide();
        var startPoint = LocationRandomizer.GetRandom();
        var destinationPoint = LocationRandomizer.GetRandom();

        var action = () => realization.BeginNewRide(startPoint, destinationPoint);

        action.Should().ThrowExactly<RideIsInprogressException>();
    }
    
    [Test]
    public void Given_BeginNewRide_When_RealizationIsCompleted_Then_CannotBeginNewRide()
    {
        Realization realization = A.Realization()
            .WithRide()
            .WithFinished()
            .WithCompleted();
        var startPoint = LocationRandomizer.GetRandom();
        var destinationPoint = LocationRandomizer.GetRandom();

        var action = () => realization.BeginNewRide(startPoint, destinationPoint);

        action.Should().ThrowExactly<RealizationAlreadyCompletedException>();
    }
}