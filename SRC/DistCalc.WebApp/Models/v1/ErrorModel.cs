using Newtonsoft.Json;

namespace DistCalc.WebApp.Models.v1
{
    internal class ErrorModel
    {
        public ErrorModel(string message)
        {
            Message = message;
        }

        [JsonProperty("error_message")]
        public string Message { get; }
    }
}