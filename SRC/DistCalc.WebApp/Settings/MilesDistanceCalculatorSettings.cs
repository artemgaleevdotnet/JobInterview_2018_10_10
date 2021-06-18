using DistCalc.DomainModel.Settings;
using Newtonsoft.Json;

namespace DistCalc.WebApp.Settings
{
    public class MilesDistanceCalculatorSettings : IMilesDistanceCalculatorSettings
    {
        [JsonProperty("EarthRadiusInMiles")] public double EarthRadiusInMiles { get; set; }
    }
}