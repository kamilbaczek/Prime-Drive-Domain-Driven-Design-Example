namespace PrimeDrive.Realizations.Domain.Rides.Stops.Policy;

public sealed class AdditionalStopsExceedException : InvalidOperationException
{
    public AdditionalStopsExceedException(int limit)
        : base($"Additional stops per ride limit is {limit}.")
    {
    }
}
