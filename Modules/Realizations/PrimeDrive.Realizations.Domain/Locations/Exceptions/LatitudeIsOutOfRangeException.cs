namespace PrimeDrive.Realizations.Domain.Locations.Exceptions;

public sealed class LatitudeIsOutOfRangeException : InvalidOperationException
{
    public LatitudeIsOutOfRangeException() : base("Latitude is out of range")
    {
    }
}
