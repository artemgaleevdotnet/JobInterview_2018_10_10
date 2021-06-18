using DistCalc.DomainModel.Calculators;
using Microsoft.Extensions.DependencyInjection;

namespace DistCalc.Calculators
{
    public class ContainerConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICalculator, Calculator>();
        }
    }
}
