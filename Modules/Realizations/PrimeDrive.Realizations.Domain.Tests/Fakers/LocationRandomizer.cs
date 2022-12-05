namespace PrimeDrive.Realizations.Domain.Tests.Fakers;

using Locations;

internal static class LocationRandomizer
{
    internal static Location GetRandom()
    {
        var faker = new Faker();
        var latitude = faker.Address.Latitude();
        var longitude = faker.Address.Longitude();
        var location = Location.Define(latitude, longitude);

        return location;
    }
}
