namespace PrimeDrive.Realizations.Domain.Prices;

using DomainDrivenDesign.BuildingBlocks.Blocks;
using Exceptions;

[ExcludeFromCodeCoverage]
public sealed class Money : ValueObject
{
    private const int ZeroValue = 0;
    private const decimal HalfPriceDiscount = 0.5m;

    private Money(string currency, decimal value)
    {
        if (Value < ZeroValue) throw new PriceCannotBeNegativeException();

        Currency = currency;
        Value = value;
    }

    private string Currency { get; }
    public decimal Value { get; }

    public static Money operator /(Money? left, int? right)
    {
        return new Money(left.Currency, left.Value / right.Value);
    }
    public static Money operator +(Money? left, Money? right)
    {
        return new Money(left.Currency, left.Value + right.Value);
    }
    public static Money operator -(Money? left, Money? right)
    {
        return new Money(left.Currency, left.Value - right.Value);
    }

    internal static Money Zero(string currency)
    {
        return new Money(currency, ZeroValue);
    }

    public static Money From(string currency, decimal value)
    {
        return new Money(currency, value);
    }

    internal Money WithHalfDiscount()
    {
        return WithPercentageDiscount(HalfPriceDiscount);
    }

    internal Money WithPercentageDiscount(decimal discount)
    {
        return new(Currency, Value * discount);
    }
}