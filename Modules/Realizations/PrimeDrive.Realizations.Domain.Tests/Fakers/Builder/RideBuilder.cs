namespace PrimeDrive.Realizations.Domain.Tests.Fakers.Builder;

using Events;
using Extensions;

internal sealed class RideBuilder
{
    private static Realization _realization;

    public RideBuilder(Realization realization)
    {
        _realization = realization;
    }

    public RideBuilder WithStops(int stopsNumber = 3)
    {
        for (var stopNumber = 0; stopNumber <= stopsNumber; stopNumber++)
        {
            var additionalStopLocation = LocationRandomizer.GetRandom();
            _realization.AddStopPoint(additionalStopLocation);
        }

        return this;
    }

    public RideFinishedBuilder WithFinished()
    {
        var realizationBegunEvent = _realization.DomainEvents.GetEvent<RealizationBegunEvent>();
        _realization.FinishRide(realizationBegunEvent!.DestinationPoint);

        return new RideFinishedBuilder(_realization);
    }

    private static Realization Build()
    {
        return _realization;
    }

    public static implicit operator Realization(RideBuilder _)
    {
        return Build();
    }
}