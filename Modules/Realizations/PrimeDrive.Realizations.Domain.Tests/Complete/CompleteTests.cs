namespace PrimeDrive.Realizations.Domain.Tests.Complete;

using Exceptions;
using PrimeDrive.Realizations.Domain.Events;
using PrimeDrive.Realizations.Domain.Prices;
using PrimeDrive.Realizations.Domain.Tests.Extensions;
using PrimeDrive.Realizations.Domain.Tests.Fakers.Builder;

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
    public void Given_Complete_When_AllRidesAreFinished_Then_RealizationPriceIsCalcualtedProperly(Money expectedPrice, int ridesCount)
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