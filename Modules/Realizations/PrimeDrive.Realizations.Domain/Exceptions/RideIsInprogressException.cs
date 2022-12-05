namespace PrimeDrive.Realizations.Domain.Exceptions;

public sealed class RideIsInprogressException : InvalidOperationException
{
    public RideIsInprogressException() : base("Ride is in progress")
    {
    }
}
