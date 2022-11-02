namespace PrimeDrive.Realizations.Domain.Prices.Exceptions;

public sealed class PriceCannotBeNegativeException: InvalidOperationException
{
    public PriceCannotBeNegativeException() : base("Price cannot be negative")
    {
    }
}