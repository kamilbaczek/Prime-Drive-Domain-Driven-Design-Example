namespace PrimeDrive.Realizations.Domain.Tests.Extensions.Assertions.StopPointAdded;

using FluentAssertions.Primitives;
using Localization;
using Locations;
using RealizationBegun;
using Rides;
using Rides.Events;

internal sealed class StopPointAddedEventAssertions :
    ReferenceTypeAssertions<StopPointAddedEvent, StopPointAddedEventAssertions>
{
    public StopPointAddedEventAssertions(StopPointAddedEvent instance)
        : base(instance)
    {
    }

    protected override string Identifier => nameof(RealizationBegunEventAssertions);

    public AndConstraint<StopPointAddedEventAssertions> Be(RideId rideId, Location newStopPointLocation, string because = "", params object[] becauseArgs)
    {
        Subject.RideId.Should().Be(rideId);
        Subject.Location.Should().Be(newStopPointLocation);

        return new AndConstraint<StopPointAddedEventAssertions>(this);
    }
}
