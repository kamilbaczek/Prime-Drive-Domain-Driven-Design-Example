namespace PrimeDrive.Realizations.Domain.Tests;

using System.Collections;
using Events;
using Extensions;
using Fakers.Builder;
using Prices;

public class CalculatorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { Money.From("USD", 10.0m), 1  };
        yield return new object[] { Money.From("USD", 15.0m), 2 };
        yield return new object[] { Money.From("USD", 20.0m), 3 };
        yield return new object[] { Money.From("USD", 30.0m), 5 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

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
    
    [Theory]
    [TestCaseSource(typeof(CalculatorTestData))]
    public void Given_Complete_When_AllRidesAreFinished_Then_RealizationPriceIsCalucatedProperly(Money expectedPrice, int ridesCount)
    {
        Realization realization = A
            .Realization()
            .WithRide()
            .WithManyFinished(ridesCount);

        realization.Complete();

        var completedEvent = realization.DomainEvents.GetEvent<RealizationCompletedEvent>();
        completedEvent.Price.Value.Should().Be(expectedPrice.Value);
    }
}