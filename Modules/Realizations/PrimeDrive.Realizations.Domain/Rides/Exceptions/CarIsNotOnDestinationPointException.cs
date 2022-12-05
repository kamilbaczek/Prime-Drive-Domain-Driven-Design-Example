namespace PrimeDrive.Realizations.Domain.Rides.Exceptions;

using Locations;

public sealed class CarIsNotOnDestinationPointException : InvalidOperationException
{
    public CarIsNotOnDestinationPointException(Location carLocation, Location destinationLocation) : base($"Car location {carLocation} is not on destination point {destinationLocation}.")
    {
    }
}
