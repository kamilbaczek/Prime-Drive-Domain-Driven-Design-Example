namespace PrimeDrive.Realizations.Domain.Rides.Stops;

using DomainDrivenDesign.BuildingBlocks.Blocks;
using Locations;

public sealed class Stop : Entity
{
    private Stop(Location location)
    {
        Location = location;
    }
    private Location Location { get; }

    internal static Stop Create(Location location) => new(location);
}
