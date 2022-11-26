namespace PrimeDrive.Realizations.Domain;

public record struct DriverId(Guid Value)
{
    public static DriverId Create() => new(Guid.NewGuid());
}
