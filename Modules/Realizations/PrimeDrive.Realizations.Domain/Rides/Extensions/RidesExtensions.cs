namespace PrimeDrive.Realizations.Domain.Rides.Extensions;

internal static class RidesExtensions
{
    internal static Ride Get(this IList<Ride> rides, RideId rideId) => rides.Single(ride => ride.Id == rideId);

    internal static Ride? GetInprogress(this IList<Ride> rides) => rides.SingleOrDefault(ride => ride.IsInprogress);
}
