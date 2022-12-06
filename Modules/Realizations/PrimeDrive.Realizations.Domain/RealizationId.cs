namespace PrimeDrive.Realizations.Domain;

[ExcludeFromCodeCoverage]
public readonly record struct RealizationId(Guid Value)
{
    internal static RealizationId New() => new(Guid.NewGuid());
};