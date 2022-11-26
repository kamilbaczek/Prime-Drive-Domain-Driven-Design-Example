namespace PrimeDrive.Realizations.Domain.Prices;

using Rides;

internal static class DiscountCalculator
{
    internal static Money CalculateRidesPrice(IList<Ride> rides)
    {
        var finalPrice = Money.Zero(Currency.Usd);
        for (var rideNumber = 1; rideNumber <= rides.Count; rideNumber++)
        {
            if (rideNumber > 2)
            {
                finalPrice += rides[rideNumber]
                    .Price
                    .WithHalfDiscount();

                continue;
            }

            finalPrice += rides[rideNumber].Price;
        }

        return finalPrice;
    }
}
