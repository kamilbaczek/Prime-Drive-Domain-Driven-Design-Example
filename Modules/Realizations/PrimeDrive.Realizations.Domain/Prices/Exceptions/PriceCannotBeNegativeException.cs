namespace PrimeDrive.Realizations.Domain.Prices.Exceptions;

public sealed class PriceCannotBeNegativeException : InvalidOperationException
{
    public PriceCannotBeNegativeException() : base("Money cannot be negative")
    {
    }
}
