namespace PrimeDrive.Realizations.Domain;

[ExcludeFromCodeCoverage]
public readonly record struct RealizationId(Guid Value)
{
    internal static RealizationId New()
    {
        return new(Guid.NewGuid());
    }
};