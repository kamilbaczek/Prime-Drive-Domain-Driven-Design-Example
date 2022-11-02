using PrimeDrive.DomainDrivenDesign.BuildingBlocks.Blocks;

namespace PrimeDrive.Realizations.Domain.Prices;

public sealed class Price :ValueObject
{
    public string Currency { get; }
    public decimal Value { get; }

    public Price(string currency, decimal value)
    {
        if (Value < 0)
        {
        }

        Currency = currency;
        Value = value;
    }
}