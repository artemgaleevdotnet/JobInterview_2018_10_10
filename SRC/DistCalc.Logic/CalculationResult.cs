using DistCalc.DomainModel.AirportDetails;
using DistCalc.DomainModel.Managers;

namespace DistCalc.Logic
{
    internal class CalculationResult : ICalculationResult
    {
        public string RequestedIATA1 { get; set; }
        public string RequestedIATA2 { get; set; }
        public double Distance { get; set; }
        public IAirportDetails AirportDetails1 { get; set; }
        public IAirportDetails AirportDetails2 { get; set; }
    }
}