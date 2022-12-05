namespace PrimeDrive.Realizations.Domain.Tests;

using Events;
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
}