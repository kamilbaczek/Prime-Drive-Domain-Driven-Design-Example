namespace PrimeDrive.Realizations.Domain.Rides.Extensions;

internal static class RidesExtensions
{
    internal static Ride? GetInprogress(this IList<Ride> rides)
    {
        return rides.SingleOrDefault(ride => ride.IsInprogress);
    }
}
