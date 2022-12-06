namespace PrimeDrive.Realizations.Domain.Rides.Stops;

using DomainDrivenDesign.BuildingBlocks.Blocks;
using Locations;

public sealed class Stop : Entity
{
    private Stop(Location location)
    {
        Location = location;
    }
    internal Location Location { get; }

    internal static Stop Create(Location location)
    {
        return new(location);
    }
}
