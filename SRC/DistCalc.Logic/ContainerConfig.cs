using DistCalc.DomainModel.Managers;
using DistCalc.DomainModel.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace DistCalc.Logic
{
    public class ContainerConfig
    {
        public static void ConfigureServices(IServiceCollection services, IMilesDistanceCalculatorSettings settings)
        {
            services.AddSingleton<IMilesDistanceCalculatorSettings>(settings);
            services.AddSingleton<ICalculationManager, CalculationManager>();
        }
    }
}