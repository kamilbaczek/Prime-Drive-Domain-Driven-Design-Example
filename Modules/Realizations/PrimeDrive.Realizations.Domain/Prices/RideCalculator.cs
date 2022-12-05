namespace PrimeDrive.Realizations.Domain.Prices;

using Rides;

internal static class RideCalculator
{
    internal static Money Calculate(this IList<Ride> rides)
    {
        var finalPrice = Money.Zero(Currency.Usd);
        for (var rideNumber = 0; rideNumber < rides.Count; rideNumber++)
        {
            if (rideNumber > 0)
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