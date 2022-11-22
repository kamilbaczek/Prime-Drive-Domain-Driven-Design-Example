namespace PrimeDrive.Realizations.Domain.Rides.Extensions;

internal static class RidesExtensions
{
    internal static Ride Get(this IList<Ride> rides, RideId rideId)
    {
        return rides.Single(ride => ride.Id == rideId);
    }
}