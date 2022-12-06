namespace PrimeDrive.Realizations.Domain.Tests.Complete;

using System.Collections;
using PrimeDrive.Realizations.Domain.Prices;

public sealed class PriceCalculationTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { Money.From("USD", 10.0m), 1  };
        yield return new object[] { Money.From("USD", 15.0m), 2 };
        yield return new object[] { Money.From("USD", 20.0m), 3 };
        yield return new object[] { Money.From("USD", 30.0m), 5 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}