namespace PrimeDrive.Realizations.Domain.Tests.Extensions.Assertions.Localization;

using Locations;

internal static class LocalizationAssertionsExtensions
{
    internal static LocalizationAssertions Should(this Location instance) => new(instance);
}
