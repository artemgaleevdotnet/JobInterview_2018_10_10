using DistCalc.DomainModel.AirportDetails;
using DistCalc.DomainModel.Settings;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace DistCalc.Repository
{
    internal class AirportDetailsRepository : IAirportDetailsRepository
    {
        private readonly IAirportSourceSettings _settings;
        private readonly HttpClient _httpClient;

        public AirportDetailsRepository(IAirportSourceSettings settings, HttpClient httpClient)
        {
            _settings = settings;
            _httpClient = httpClient;
        }

        public async Task<IAirportDetails> GetByIATA(string iata)
        {
            if (string.IsNullOrEmpty(iata))
            {
                // log or exception

                return null;
            }

            var url = string.Format(_settings.UrlTemplate, iata.ToUpper(CultureInfo.InvariantCulture));

            var requestResult = await _httpClient.GetStringAsync(url);

            var details = JsonConvert.DeserializeObject<AirportDetails>(requestResult);

            return details;
        }
    }
}
