namespace PrimeDrive.Realizations.Domain.Locations.Exceptions;

[ExcludeFromCodeCoverage]
public sealed class LongitudeIsOutOfRangeException : InvalidOperationException
{
    public LongitudeIsOutOfRangeException() : base("Longitude is out of range")
    {
    }
}
