using DistCalc.DomainModel.Managers;
using Newtonsoft.Json;

namespace DistCalc.WebApp.Models.v1
{
    internal class DistanceCalculationModel
    {
        public DistanceCalculationModel(ICalculationResult calculationResult, string requestUrl)
        {
            IATA1 = calculationResult.RequestedIATA1;
            IATA2 = calculationResult.RequestedIATA2;
            City1 = calculationResult.AirportDetails1?.City;
            City2 = calculationResult.AirportDetails2?.City;
            Distance = calculationResult.Distance;
            RequestUrl = requestUrl;
        }

        [JsonProperty("to_city")]
        public string City2 { get; }
        [JsonProperty("from_city")]
        public string City1 { get; }
        [JsonProperty("request_url")]
        public string RequestUrl { get; }
        [JsonProperty("distance")]
        public double Distance { get; }
        [JsonProperty("from_iata")]
        public string IATA1 { get; }
        [JsonProperty("to_iata")]
        public string IATA2 { get; }
    }
}