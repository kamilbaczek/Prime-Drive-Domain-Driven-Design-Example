using PrimeDrive.DomainDrivenDesign.BuildingBlocks.Blocks;
using PrimeDrive.Realizations.Domain.Locations.Exceptions;

namespace PrimeDrive.Realizations.Domain.Locations;

public sealed class Location : ValueObject
{
    private double _latitude = double.NaN;
    private double _longitude = double.NaN;

    public Double Latitude
    {
        get => _latitude;
        set
        {
            if (value > 90.0 || value < -90.0)
            {
                throw new LatitudeIsOutOfRangeException();
            }
            _latitude = value;
        }
    }

    public Double Longitude
    {
        get => _longitude;
        set
        {
            if (value > 180.0 || value < -180.0)
            {
                throw new LongitudeIsOutOfRangeException();
            }
            _longitude = value;
        }
    }

    public Location(Double latitude, Double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}