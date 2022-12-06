namespace PrimeDrive.Realizations.Domain.Tests.Fakers.Builder;

using Events;
using Extensions;

internal sealed class ManyRidesBuilder
{
    private static Realization? _realization;
    private const int InitialRide = 1;

    public ManyRidesBuilder(Realization? realization) =>
        _realization = realization;
    
    public ManyRidesBuilder WithManyFinished(int ridesToGenerate = 3)
    {
        var realizationBegunEvent = _realization!.DomainEvents.GetEvent<RealizationBegunEvent>();
        _realization.FinishRide(realizationBegunEvent!.DestinationPoint);

        for (var ride = 0; ride < ridesToGenerate - InitialRide; ride++)
        {
            var stopLocation = LocationRandomizer.GetRandom();
            var destinationPoint = LocationRandomizer.GetRandom();
            _realization.BeginNewRide(stopLocation, destinationPoint);
            _realization.FinishRide(destinationPoint);
        }

        return this;
    }

    private static Realization? Build() => _realization;

    public static implicit operator Realization?(ManyRidesBuilder _) =>
        Build();
}