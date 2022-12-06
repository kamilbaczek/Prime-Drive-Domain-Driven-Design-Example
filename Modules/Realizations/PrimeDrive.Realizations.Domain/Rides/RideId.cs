namespace PrimeDrive.Realizations.Domain.Rides;

[ExcludeFromCodeCoverage]
public record struct RideId(Guid Value)
{
    internal static RideId Create() => new(Guid.NewGuid());
}