using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MyQuiver.Model
{
    public sealed class DistanceModel
    {
        private readonly int _distance;
        private readonly string _unit;

        public DistanceModel()
        {
        }

        public DistanceModel(int distance, string unit)
        {
            _distance = distance;
            _unit = unit;
        }

        [BsonElement("distance")]
        public int Distance { get => _distance; }

        [BsonElement("unit")]
        public string Unit { get => _unit; }
    }
}
