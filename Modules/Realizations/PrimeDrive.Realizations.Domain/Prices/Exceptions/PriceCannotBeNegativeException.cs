namespace PrimeDrive.Realizations.Domain.Prices.Exceptions;

[ExcludeFromCodeCoverage]
public sealed class PriceCannotBeNegativeException : InvalidOperationException
{
    public PriceCannotBeNegativeException() : base("Money cannot be negative")
    {
    }
}