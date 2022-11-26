namespace PrimeDrive.Realizations.Domain.Tests.Fakers;

internal static class DriverRandomizer
{
    internal static DriverId GetRandom() => new(Guid.NewGuid());
}
