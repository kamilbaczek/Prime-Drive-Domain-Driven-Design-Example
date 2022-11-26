namespace PrimeDrive.Realizations.Domain;

public readonly record struct RealizationStatus(string Value)
{
    internal static RealizationStatus InProgress => new(nameof(InProgress));
    internal static RealizationStatus Completed => new(nameof(Completed));
    internal static RealizationStatus Canceled => new(nameof(Canceled));
}
