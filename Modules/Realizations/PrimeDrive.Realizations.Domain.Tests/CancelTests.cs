namespace PrimeDrive.Realizations.Domain.Tests;

using Events;
using Exceptions;
using Extensions;
using Fakers.Builder;

public class CancelTests
{
    [Test]
    public void Given_Cancel()
    {
        Realization realization = A
            .Realization()
            .WithRide();

        realization.Cancel();
        
        var realizationCancelledEvent = realization.DomainEvents.GetEvent<RealizationCancelledEvent>();
        realizationCancelledEvent.RealizationId.Should().Be(realization.Id);
    }
    
    [Test]
    public void Given_Cancel_When_RealizationIsNotInProgress_Then_ThrowsException()
    {
        Realization realization = A
            .Realization()
            .WithRide();
        realization.Cancel();
        
        var action = () => realization.Cancel();

        action.Should().ThrowExactly<RealizationAlreadyCompletedException>();
    }
}