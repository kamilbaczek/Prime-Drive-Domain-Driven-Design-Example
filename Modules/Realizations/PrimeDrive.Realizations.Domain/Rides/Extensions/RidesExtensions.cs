namespace PrimeDrive.Realizations.Domain.Rides.Extensions;

using Rides;

internal static class RidesExtensions
{
    internal static Ride Get(this IList<Ride> rides, RideId rideId) => rides.Single(ride => ride.Id == rideId);
}