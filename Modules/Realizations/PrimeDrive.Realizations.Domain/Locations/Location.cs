namespace PrimeDrive.Realizations.Domain.Locations;

using Exceptions;

[ExcludeFromCodeCoverage]
public sealed class Location : ValueObject
{
    private double _latitude = double.NaN;
    private double _longitude = double.NaN;

    private Location(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
    public static Location Define(double latitude, double longitude)
    {
        return new(latitude, longitude);
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
