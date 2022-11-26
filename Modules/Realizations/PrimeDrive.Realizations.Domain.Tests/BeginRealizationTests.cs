namespace PrimeDrive.Realizations.Domain.Tests;

using Events;
using Extensions;
using Extensions.Assertions.RealizationBegun;
using Fakers;

public class BeginRealizationTests
{
    [Test]
    public void Given_Begin_Then_RealizationHasBegun()
    {
        var pickupPoint = LocationRandomizer.GetRandom();
        var destinationPoint = LocationRandomizer.GetRandom();
        var driver = DriverRandomizer.GetRandom();
        var serviceRequestId = ServiceRequestRandomizer.GetRandom();

        var realization = Realization.Begin(serviceRequestId, driver, pickupPoint, destinationPoint);

        var @event = realization.DomainEvents.GetEvent<RealizationBegunEvent>();
        @event!.Should().Be(serviceRequestId, driver, destinationPoint, pickupPoint);
    }
}