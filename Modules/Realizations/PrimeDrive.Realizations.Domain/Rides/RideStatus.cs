namespace PrimeDrive.Realizations.Domain.Rides;

[ExcludeFromCodeCoverage]
public readonly record struct RideStatus(string Value)
{
    internal static RideStatus InProgress => new(nameof(InProgress));
    internal static RideStatus Finished => new(nameof(Finished));
    internal static RideStatus Canceled => new(nameof(Canceled));
}
