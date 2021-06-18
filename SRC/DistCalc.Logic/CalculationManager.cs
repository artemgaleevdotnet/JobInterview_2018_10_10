using System;
using System.Threading.Tasks;
using DistCalc.DomainModel.AirportDetails;
using DistCalc.DomainModel.Calculators;
using DistCalc.DomainModel.Managers;
using DistCalc.DomainModel.Settings;

namespace DistCalc.Logic
{
    internal class CalculationManager : ICalculationManager
    {
        private const int DegreesToRadians = 180;
        private readonly IAirportDetailsRepository _airportDetailsRepository;
        private readonly ICalculator _calculator;
        private readonly IMilesDistanceCalculatorSettings _settings;

        public CalculationManager(IAirportDetailsRepository airportDetailsRepository, ICalculator calculator, IMilesDistanceCalculatorSettings settings)
        {
            _airportDetailsRepository = airportDetailsRepository;
            _calculator = calculator;
            _settings = settings;
        }

        public async Task<ICalculationResult> GetDistance(string iata1, string iata2)
        {
            var airport1Task = _airportDetailsRepository.GetByIATA(iata1);
            var airport2Task = _airportDetailsRepository.GetByIATA(iata2);

            await Task.WhenAll(airport1Task, airport2Task);

            var airport1 = airport1Task.Result;
            var airport2 = airport2Task.Result;

            var result = new CalculationResult
            {
                RequestedIATA1 = iata1,
                RequestedIATA2 = iata2
            };

            if (airport1 == null)
            {
                // log error

                return result;
            }

            result.AirportDetails1 = airport1;

            if (airport2 == null)
            {
                // log error

                return result;
            }

            result.AirportDetails2 = airport2;

            // latitude. recalculation from degrees to radians
            var lat1 = airport1.Location.Latitude * Math.PI / DegreesToRadians;
            var lat2 = airport2.Location.Latitude * Math.PI / DegreesToRadians;

            //longitude. recalculation from degrees to radians
            var lon1 = airport1.Location.Longitude * Math.PI / DegreesToRadians;
            var lon2 = airport2.Location.Longitude * Math.PI / DegreesToRadians;

            result.Distance = _calculator.Calculate(lat1, lat2, lon1, lon2, _settings.EarthRadiusInMiles);

            return result;
        }
    }
}
