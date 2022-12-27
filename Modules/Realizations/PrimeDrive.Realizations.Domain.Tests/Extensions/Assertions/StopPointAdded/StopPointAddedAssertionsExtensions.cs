namespace PrimeDrive.Realizations.Domain.Tests.Extensions.Assertions.StopPointAdded;

using Rides.Events;

internal static class StopPointAddedAssertionsExtensions
{
    internal static StopPointAddedEventAssertions Should(this StopPointAddedEvent instance)
    {
        return new(instance);
    }
}
