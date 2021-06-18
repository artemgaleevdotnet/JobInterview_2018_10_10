using DistCalc.DomainModel.AirportDetails;

namespace DistCalc.DomainModel.Managers
{
    public interface ICalculationResult
    {
        string RequestedIATA1 { get; }
        string RequestedIATA2 { get; }
        double Distance { get; }
        IAirportDetails AirportDetails1 { get; }
        IAirportDetails AirportDetails2 { get; }
    }
}