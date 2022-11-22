namespace PrimeDrive.Realizations.Domain.Locations;

using DomainDrivenDesign.BuildingBlocks.Blocks;
using Exceptions;

public sealed class Location : ValueObject
{
    private double _latitude = double.NaN;
    private double _longitude = double.NaN;

    public Location(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public double Latitude
    {
        get => _latitude;
        set
        {
            if (value > 90.0 || value < -90.0) throw new LatitudeIsOutOfRangeException();

            _latitude = value;
        }
    }

    public double Longitude
    {
        get => _longitude;
        set
        {
            if (value > 180.0 || value < -180.0) throw new LongitudeIsOutOfRangeException();

            _longitude = value;
        }
    }
}
