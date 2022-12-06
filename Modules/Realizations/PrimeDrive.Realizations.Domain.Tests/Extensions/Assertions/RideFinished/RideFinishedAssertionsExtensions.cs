namespace PrimeDrive.Realizations.Domain.Tests.Extensions.Assertions.RideFinished;

using Events;

internal static class RideFinishedAssertionsExtensions
{
    internal static RideFinishedEventAssertions Should(this RideFinishedEvent instance)
    {
        return new(instance);
    }
}
