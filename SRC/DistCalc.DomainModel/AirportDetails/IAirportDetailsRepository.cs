using System.Threading.Tasks;

namespace DistCalc.DomainModel.AirportDetails
{
    public interface IAirportDetailsRepository
    {
        Task<IAirportDetails> GetByIATA(string iata);
    }
}
