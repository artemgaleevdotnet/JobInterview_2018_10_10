namespace DistCalc.DomainModel.AirportDetails
{
    public interface IAirportDetails
    {
        string Country { get; }
        string CityIATA { get; }
        string IATA { get; }
        string City { get; }
        string TimeZoneRegionName { get; }
        string CountryIATA { get; }
        int Rating { get; }
        string Name { get; }
        ILocation Location { get; }
        string Type { get; }
        int Hubs { get; }
    }
}
