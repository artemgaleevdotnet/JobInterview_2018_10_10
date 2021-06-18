using System.Threading.Tasks;

namespace DistCalc.DomainModel.Calculators
{
    public interface ICalculator
    {
        double Calculate(double lat1, double lat2, double lon1, double lon2, double radius);
    }
}
