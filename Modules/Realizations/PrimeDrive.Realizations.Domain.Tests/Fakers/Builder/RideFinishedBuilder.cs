namespace PrimeDrive.Realizations.Domain.Tests.Fakers.Builder;

internal sealed class RideFinishedBuilder
{
    private static Realization _realization;

    public RideFinishedBuilder(Realization realization)
    {
        _realization = realization;
    }

    public RideFinishedBuilder WithCompleted()
    {
        _realization.Complete();

        return this;
    }

    private static Realization Build()
    {
        return _realization;
    }

    public static implicit operator Realization(RideFinishedBuilder _)
    {
        return Build();
    }
}
