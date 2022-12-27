namespace PrimeDrive.Realizations.Domain.Tests.Complete;

using Exceptions;
using Events;
using Prices;
using Extensions;
using Fakers.Builder;

public class CompleteTests
{
    [Test]
    public void Given_Complete_When_AllRidesAreFinished_Then_RealizationIsCompleted()
    {
        Realization realization = A
            .Realization()
            .WithRide()
            .WithFinished();

        realization.Complete();

        var completedEvent = realization.DomainEvents.GetEvent<RealizationCompletedEvent>();
        completedEvent.Should().NotBeNull();
    }

    [Test]
    public void Given_Complete_When_RideIsInprogress_Then_RealizationCannotBeCompleted()
    {
        Realization realization = A
            .Realization()
            .WithRide();

        var action = () => realization.Complete();

        action.Should().ThrowExactly<RideIsInprogressException>();
    }

    [Theory]
    [TestCaseSource(typeof(PriceCalculationTestData))]
    public void Given_Complete_When_AllRidesAreFinished_Then_RealizationPriceIsCalculatedProperly(Money expectedPrice, int ridesCount)
    {
        Realization realization = A
            .Realization()
            .WithManyRides()
            .WithManyFinished(ridesCount);

        realization.Complete();

        var completedEvent = realization.DomainEvents.GetEvent<RealizationCompletedEvent>();
        completedEvent!.Price.Value.Should().Be(expectedPrice.Value);
    }
}