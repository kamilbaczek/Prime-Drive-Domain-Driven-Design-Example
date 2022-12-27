namespace PrimeDrive.Realizations.Domain.Tests.Extensions.Assertions.Localization;

using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Locations;

internal sealed class LocalizationAssertions :
    ReferenceTypeAssertions<Location, LocalizationAssertions>
{
    public LocalizationAssertions(Location instance)
        : base(instance)
    {
    }

    protected override string Identifier => nameof(LocalizationAssertions);

    public AndConstraint<LocalizationAssertions> Be(
        Location location, string because = "", params object[] becauseArgs)
    {
        using (new AssertionScope())
        {
            location.Latitude.Should().Be(location.Latitude, because, becauseArgs);
            location.Longitude.Should().Be(location.Longitude, because, becauseArgs);
        }

        return new AndConstraint<LocalizationAssertions>(this);
    }
}
