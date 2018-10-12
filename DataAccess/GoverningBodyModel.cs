using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;

namespace MyQuiver.Model
{
    /// <summary>
    /// An archery governing body which handles tournaments, olympic qualifiers, and archery development
    /// </summary>
    [BsonDiscriminator("GoverningBody")]
    public class GoverningBodyModel : DbModel<GoverningBodyModel>
    {
        /// <summary>
        /// Get or set the name of the governing body
        /// </summary>
        [BsonElement("name"), BsonRequired]
        public string BodyName { get; set; }

        /// <summary>
        /// Get or set the address line of its headquarters
        /// </summary>
        [BsonElement("hqAddr"), BsonRequired]
        public string HeadquartersAddressLine { get; set; }
        [BsonElement("hqAddr2")]
        public string HeadquartersSecondAddressLine { get; set; }
        [BsonElement("hqAddr3")]
        public string HeadquartersThirdAddressLine { get; set; }

        /// <summary>
        /// Get or set the city of its headquarters
        /// </summary>
        [BsonElement("hqCity"), BsonRequired]
        public string HeadquartersCity { get; set; }

        /// <summary>
        /// Get or set the state or province of the governing body
        /// </summary>
        [BsonElement("state"), BsonRequired]
        public string StateProvince { get; set; }
        [BsonElement("postalCode"), BsonRequired]
        public string HeadquartersPostalCode { get; set; }

        /// <summary>
        /// Get or set the country in which the governing body belongs
        /// </summary>
        [BsonElement("country"), BsonRequired]
        public string Country { get; set; }
        [BsonElement("website"), BsonRequired]
        public string Website { get; set; }
        [BsonElement("logo"), BsonRequired]
        public string LogoPath { get; set; }

        /// <summary>
        /// Get or set whether this governing body has the authority to determine olympians
        /// </summary>
        [BsonElement("olympicQualifier"), BsonRequired]
        public bool DeterminesOlympicQualifiers { get; set; }
    }
}
