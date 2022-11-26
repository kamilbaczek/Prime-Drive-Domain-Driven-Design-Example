namespace PrimeDrive.Realizations.Domain.Rides.Stops;

internal sealed class AdditionalStopsPerRideLimitPolicy
{
    private readonly int _additionalStopsCount;
    private const int Limit = 10;
    public AdditionalStopsPerRideLimitPolicy(int additionalStopsCount)
    {
        _additionalStopsCount = additionalStopsCount;
    }


    public void Guard()
    {
        if (_additionalStopsCount > Limit)
        {
            throw new AdditionalStopsExceedException(Limit);
        }
    }
}

public sealed class AdditionalStopsExceedException : InvalidOperationException
{
    public AdditionalStopsExceedException(int limit)
        : base($"Additional stops per ride limit is {limit}.")
    {
    }
}