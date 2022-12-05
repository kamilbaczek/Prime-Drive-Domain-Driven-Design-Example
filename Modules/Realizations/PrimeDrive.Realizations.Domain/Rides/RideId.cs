namespace PrimeDrive.Realizations.Domain.Rides;

public record struct RideId(Guid Value)
{
    internal static RideId Create() => new(Guid.NewGuid());
}
