namespace PrimeDrive.Realizations.Domain.Prices;

using DomainDrivenDesign.BuildingBlocks.Blocks;
using Exceptions;

public sealed class Money : ValueObject
{
    private const int ZeroValue = 0;

    private string Currency { get; }
    private decimal Value { get; }

    private Money(string currency, decimal value)
    {
        if (Value < ZeroValue)
        {
            throw new PriceCannotBeNegativeException();
        }

        Currency = currency;
        Value = value;
    }

    public static Money operator /(Money? left, int? right) => new(left.Currency, left.Value / right.Value);
    public static Money operator +(Money? left, Money? right) => new(left.Currency, left.Value + right.Value);
    public static Money operator -(Money? left, Money? right) => new(left.Currency, left.Value - right.Value);

    internal static Money Zero(string currency) => new(currency, ZeroValue);

    internal static Money From(string currency, decimal value) => new(currency, value);
}