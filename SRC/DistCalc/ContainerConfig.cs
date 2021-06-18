using System;
using DistCalc.DomainModel.AirportDetails;
using DistCalc.DomainModel.Settings;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace DistCalc.Repository
{
    public class ContainerConfig
    {
        public static void ConfigureServices(IServiceCollection services, IAirportSourceSettings settings)
        {
            services.AddSingleton(settings);
            services.AddHttpClient<IAirportDetailsRepository, AirportDetailsRepository>()
                .AddTransientHttpErrorPolicy(x => x.RetryAsync(settings.RetryCount))
                .AddTransientHttpErrorPolicy(x => x.CircuitBreakerAsync(settings.EventsBeforeBreaking,
                    TimeSpan.FromMilliseconds(settings.DurationOfBreakMsec)));

        }
    }
}