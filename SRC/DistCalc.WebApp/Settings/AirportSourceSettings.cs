using DistCalc.DomainModel.Settings;
using Newtonsoft.Json;

namespace DistCalc.WebApp.Settings
{
    public class AirportSourceSettings : IAirportSourceSettings
    {
        [JsonProperty("UrlTemplate")] public string UrlTemplate { get; set; }
        [JsonProperty("RetryCount")] public int RetryCount { get; set; }
        [JsonProperty("EventsBeforeBreaking")] public int EventsBeforeBreaking { get; set; }
        [JsonProperty("DurationOfBreakMsec")] public int DurationOfBreakMsec { get; set; }
    }
}