namespace PrimeDrive.Realizations.Domain;

public readonly record struct RealizationId(Guid Value)
{
    internal static RealizationId New() => new(Guid.NewGuid());
};