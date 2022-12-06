namespace PrimeDrive.Realizations.Domain.Tests.Extensions.Assertions.RealizationBegun;

using Events;

internal static class RealizationAssertionsExtensions
{
    internal static RealizationBegunEventAssertions Should(this RealizationBegunEvent instance)
    {
        return new(instance);
    }
}
