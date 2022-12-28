namespace PrimeDrive.Realizations.Domain.Rides.Stops;

using Locations;

public sealed class Stop : Entity
{
    private Stop(Location location)
    {
    }
    
    internal Location Location { get; }

    internal static Stop Create(Location location)
    {
        return new(location);
    }
}