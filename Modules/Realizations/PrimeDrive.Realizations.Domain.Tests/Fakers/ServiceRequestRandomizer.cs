namespace PrimeDrive.Realizations.Domain.Tests.Fakers;

internal static class ServiceRequestRandomizer
{
    internal static ServiceRequestId GetRandom()
    {
        return new(Guid.NewGuid());
    }
}
