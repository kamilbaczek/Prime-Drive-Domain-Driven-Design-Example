namespace PrimeDrive.Realizations.Domain.Tests;

using Events;
using Exceptions;
using Extensions;
using Extensions.Assertions.StopPointAdded;
using Fakers;
using Fakers.Builder;
using Rides.Events;
using Rides.Stops.Policy;

public class AddStopToRidesTests
{
    [Test]
    public void Given_AddStop_Then_StopIsAdded()
    {
        Realization realization = A.Realization();
        var realizationBegunEvent = realization.DomainEvents.GetEvent<RealizationBegunEvent>();
        var additionalStopLocation = LocationRandomizer.GetRandom();

        realization.AddStopPoint(additionalStopLocation);

        var stopPointAddedEvent = realization.DomainEvents.GetEvent<StopPointAddedEvent>();
        stopPointAddedEvent!.Should().Be(realizationBegunEvent.RideId, additionalStopLocation);
    }

    [TestCase(10)]
    public void Given_AddStop_When_AdditionalStopsLimitWasExceeded_Then_AdditionalStopsExceedException(int stopsLimit)
    {
        Realization realization = A
            .Realization()
            .WithRide()
            .WithStops(stopsLimit);
        var additionalStopLocation = LocationRandomizer.GetRandom();

        var action = () => realization.AddStopPoint(additionalStopLocation);

        action.Should().ThrowExactly<AdditionalStopsExceedException>();
    }

    [Test]
    public void Given_AddStop_When_RealizationIsNotInprogress_Then_RealizationHasToBeInprogressException()
    {
        Realization realization = A
            .Realization()
            .WithRide()
            .WithStops()
            .WithFinished()
            .WithCompleted();
        var additionalStopLocation = LocationRandomizer.GetRandom();

        var action = () => realization.AddStopPoint(additionalStopLocation);

        action.Should().ThrowExactly<RealizationAlreadyCompletedException>();
    }
}
