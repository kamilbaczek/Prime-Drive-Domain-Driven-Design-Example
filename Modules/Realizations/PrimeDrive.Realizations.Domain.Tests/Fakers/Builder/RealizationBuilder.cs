namespace PrimeDrive.Realizations.Domain.Tests.Fakers.Builder;

using Locations;

internal sealed class RealizationBuilder
{
    private static Location _pickupPoint = LocationRandomizer.GetRandom();
    private static Location _destinationPoint = LocationRandomizer.GetRandom();
    private static DriverId _driver = DriverRandomizer.GetRandom();
    private static ServiceRequestId _serviceRequestId = ServiceRequestRandomizer.GetRandom();

    public RealizationBuilder()
    {
        _pickupPoint = LocationRandomizer.GetRandom();
        _destinationPoint = LocationRandomizer.GetRandom();
        _driver = DriverRandomizer.GetRandom();
        _serviceRequestId = ServiceRequestRandomizer.GetRandom();
    }

    private static Realization Build()
    {
        return Realization.Begin(_serviceRequestId, _driver, _pickupPoint, _destinationPoint);
    }

    internal RideBuilder WithRide()
    {
        return new(Build());
    }

    internal ManyRidesBuilder WithManyRides()
    {
        return new(Build());
    }

    public static implicit operator Realization(RealizationBuilder _)
    {
        return Build();
    }
}