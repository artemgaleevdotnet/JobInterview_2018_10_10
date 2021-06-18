using DistCalc.DomainModel.AirportDetails;
using Newtonsoft.Json;

namespace DistCalc.Repository
{
    internal class Location : ILocation
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }
}