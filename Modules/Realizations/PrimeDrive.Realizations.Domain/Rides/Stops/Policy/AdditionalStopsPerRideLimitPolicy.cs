namespace PrimeDrive.Realizations.Domain.Rides.Stops.Policy;

internal sealed class AdditionalStopsPerRideLimitPolicy
{
    private readonly int _additionalStopsCount;
    private const int Limit = 2;

    public AdditionalStopsPerRideLimitPolicy(int additionalStopsCount)
    {
        _additionalStopsCount = additionalStopsCount;
    }

    public void Validate()
    {
        if (_additionalStopsCount > Limit) throw new AdditionalStopsExceedException(Limit);
    }
}