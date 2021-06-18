using DistCalc.DomainModel.Calculators;
using System;

namespace DistCalc.Calculators
{
    internal class Calculator : ICalculator
    {
        public double Calculate(double lat1, double lat2, double lon1, double lon2, double radius)
        {
            var cosLat1 = Math.Cos(lat1);
            var cosLat2 = Math.Cos(lat2);
            var sinLat1 = Math.Sin(lat1);
            var sinLat2 = Math.Sin(lat2);
            var cosLonDelta = Math.Cos(lon2 - lon1);

            var d = Math.Acos(sinLat1 * sinLat2 + cosLat1 * cosLat2 * cosLonDelta);

            var l = d * radius;
            
            return l;
        }
    }
}