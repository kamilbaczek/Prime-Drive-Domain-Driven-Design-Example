namespace PrimeDrive.Realizations.Domain.Tests.Fakers.Builder;

using Events;
using Extensions;

internal sealed class RideBuilder
{
    private static Realization _realization;

    public RideBuilder(Realization realization) =>
        _realization = realization;

    public RideBuilder WithStops(int stopsNumber)
    {
        var realizationBegunEvent = _realization.DomainEvents.GetEvent<RealizationBegunEvent>();
        for (var stopNumber = 0; stopNumber <= stopsNumber; stopNumber++)
        {
            var additionalStopLocation = LocationRandomizer.GetRandom();
            _realization.AddStopPoint(realizationBegunEvent!.RideId, additionalStopLocation);
        }

        return this;
    }

    private static Realization Build() => _realization;

    public static implicit operator Realization(RideBuilder _) =>
        Build();
}