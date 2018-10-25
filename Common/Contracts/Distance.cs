using System;
namespace MyQuiver.Contracts
{
    public class Distance
    {
        public Distance()
        {
        }

        private readonly int _distance;
        private readonly string _unit;

        public Distance(int distance, string unit)
        {
            _distance = distance;
            _unit = unit;
        }

        public int DistanceMeasurement { get => _distance; }

        public string Unit { get => _unit; }
    }
}
