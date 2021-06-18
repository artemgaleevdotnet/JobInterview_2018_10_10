using DistCalc.DomainModel.AirportDetails;
using Newtonsoft.Json;

namespace DistCalc.Repository
{
    internal class AirportDetails : IAirportDetails
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("city_iata")]
        public string CityIATA { get; set; }
        [JsonProperty("iata")]
        public string IATA { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("timezone_region_name")]
        public string TimeZoneRegionName { get; set; }
        [JsonProperty("country_iata")]
        public string CountryIATA { get; set; }
        [JsonProperty("rating")]
        public int Rating { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        //[JsonProperty("location")]
        public Location Location { get; set; }
        [JsonIgnore]
        ILocation IAirportDetails.Location => Location;
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("hubs")]
        public int Hubs { get; set; }
    }
}