namespace PrimeDrive.Realizations.Domain.Tests.Extensions.Assertions.RealizationBegun;

using Events;
using FluentAssertions.Primitives;
using Localization;
using Locations;

internal sealed class RealizationBegunEventAssertions :
    ReferenceTypeAssertions<RealizationBegunEvent, RealizationBegunEventAssertions>
{
    public RealizationBegunEventAssertions(RealizationBegunEvent instance)
        : base(instance)
    {
    }

    protected override string Identifier => nameof(RealizationBegunEventAssertions);

    public AndConstraint<RealizationBegunEventAssertions> Be(ServiceRequestId serviceRequestId, DriverId driverId, Location destinationPoint, Location pickupPoint, string because = "",
        params object[] becauseArgs)
    {
        Subject.RealizationId.Should().NotBeNull();
        Subject.DestinationPoint.Should().Be(destinationPoint);
        Subject.PickupPoint.Should().Be(pickupPoint);
        Subject.RealizationId.Should().NotBeNull();
        Subject.DriverId.Should().Be(driverId);
        Subject.RideId.Should().NotBeNull();
        Subject.ServiceRequestId.Should().Be(serviceRequestId);

        return new AndConstraint<RealizationBegunEventAssertions>(this);
    }
}
