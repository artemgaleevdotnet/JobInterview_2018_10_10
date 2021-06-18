using System.Threading.Tasks;

namespace DistCalc.DomainModel.Managers
{
    public interface ICalculationManager
    {
        Task<ICalculationResult> GetDistance(string iata1, string iata2);
    }
}
