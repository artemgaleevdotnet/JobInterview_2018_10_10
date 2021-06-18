using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DistCalc.WebApp.HealthCheck
{
    public class AirportDetailsServiceHealthCheck : IHealthCheck
    {
        private readonly string _urlTemplate;
        private static readonly HttpClient Client = new HttpClient();

        public AirportDetailsServiceHealthCheck(string urlTemplate)
        {
            _urlTemplate = urlTemplate;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            var url = string.Format(_urlTemplate, "AMS");
            HttpResponseMessage message;
            try
            {
                message = await Client.GetAsync(url, cancellationToken);
            }
            catch (Exception ex)
            {
                return new HealthCheckResult(context.Registration.FailureStatus, exception: ex);
            }

            if (message.IsSuccessStatusCode)
            {
                return new HealthCheckResult(HealthStatus.Healthy);
            }

            return new HealthCheckResult(context.Registration.FailureStatus, message.ReasonPhrase);
        }
    }
}