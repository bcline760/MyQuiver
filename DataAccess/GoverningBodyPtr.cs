using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MyQuiver.Model
{
    public class GoverningBodyPtr : DbModel<GoverningBodyPtr>
    {
        public GoverningBodyPtr()
        {
        }
        /// <summary>
        /// Get or set the name of the governing body
        /// </summary>
        [BsonElement("name"), BsonRequired]
        public string BodyName { get; set; }
    }
}
