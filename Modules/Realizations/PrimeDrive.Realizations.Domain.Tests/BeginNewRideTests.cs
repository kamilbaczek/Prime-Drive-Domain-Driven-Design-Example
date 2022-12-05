namespace PrimeDrive.Realizations.Domain.Tests;

using Events;
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

        realization.StartNewRide(startPoint, destinationPoint);

        var newRideBegunEvent = realization.DomainEvents.GetEvent<NewRideBegunEvent>();
        newRideBegunEvent.Should().NotBeNull();
    }
}