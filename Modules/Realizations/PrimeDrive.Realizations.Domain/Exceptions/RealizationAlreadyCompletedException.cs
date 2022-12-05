namespace PrimeDrive.Realizations.Domain.Exceptions;

public sealed class RealizationAlreadyCompletedException : InvalidOperationException
{
    public RealizationAlreadyCompletedException(RealizationStatus status) : base($"Ride is in progress {status}")
    {
    }
}
