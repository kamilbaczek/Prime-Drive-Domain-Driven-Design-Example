namespace PrimeDrive.Realizations.Domain.Tests.Extensions.Assertions.StopPointAdded;

using PrimeDrive.Realizations.Domain.Rides.Events;

internal static class StopPointAddedAssertionsExtensions
{
    internal static StopPointAddedEventAssertions Should(this StopPointAddedEvent instance) => new(instance);
}