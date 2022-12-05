namespace PrimeDrive.Realizations.Domain.Tests.Extensions.Assertions.RideFinished;

using Events;
using FluentAssertions.Primitives;
using Rides;

internal sealed class RideFinishedEventAssertions :
    ReferenceTypeAssertions<RideFinishedEvent, RideFinishedEventAssertions>
{
    public RideFinishedEventAssertions(RideFinishedEvent instance)
        : base(instance)
    {
    }

    protected override string Identifier => nameof(RideFinishedEventAssertions);

    public AndConstraint<RideFinishedEventAssertions> Be(RealizationId realizationId, RideId rideId)
    {
        Subject.RealizationId.Should().Be(realizationId);
        Subject.RideId.Should().Be(rideId);

        return new AndConstraint<RideFinishedEventAssertions>(this);
    }
}