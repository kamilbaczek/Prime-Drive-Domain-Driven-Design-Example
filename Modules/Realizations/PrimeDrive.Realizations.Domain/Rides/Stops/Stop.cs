using PrimeDrive.DomainDrivenDesign.BuildingBlocks.Blocks;
using PrimeDrive.Realizations.Domain.Locations;

namespace PrimeDrive.Realizations.Domain.Rides.Stops;

public sealed class Stop : Entity
{
    private Location Location { get; }

    private Stop(Location location)
    {
        Location = location;
    }

    internal static Stop Create(Location location) => new(location);
}