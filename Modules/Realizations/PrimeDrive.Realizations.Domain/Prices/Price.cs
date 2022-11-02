namespace PrimeDrive.Realizations.Domain.Prices;

using DomainDrivenDesign.BuildingBlocks.Blocks;
using Exceptions;

public sealed class Price : ValueObject
{
    private const int Zero = 0;
    public string Currency { get; }
    public decimal Value { get; }

    public Price(string currency, decimal value)
    {
        if (Value < Zero)
        {
            throw new PriceCannotBeNegativeException();
        }

        Currency = currency;
        Value = value;
    }
}