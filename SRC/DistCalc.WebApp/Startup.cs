using DistCalc.WebApp.HealthCheck;
using DistCalc.WebApp.Settings;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace DistCalc.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var distanceCalculatorSettings = new MilesDistanceCalculatorSettings();
            Configuration.Bind("DistanceCalculatorSettings", distanceCalculatorSettings);

            var airportSourceSettings = new AirportSourceSettings();
            Configuration.Bind("AirportSourceSettings", airportSourceSettings);

            Calculators.ContainerConfig.ConfigureServices(services);
            Repository.ContainerConfig.ConfigureServices(services, airportSourceSettings);
            Logic.ContainerConfig.ConfigureServices(services, distanceCalculatorSettings);

            services.AddHealthChecks().AddCheck("AirportDetailsService",
                new AirportDetailsServiceHealthCheck(airportSourceSettings.UrlTemplate));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "API", Version = "v1" });

            });
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Distance calculator API V1");
                });
            app.UseSwagger();

            app.UseHealthChecks("/hc");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
