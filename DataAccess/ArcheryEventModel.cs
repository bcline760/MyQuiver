using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyQuiver.Model
{
    [BsonDiscriminator("ArcheryEvent")]
    public class ArcheryEventModel : DbModel<ArcheryEventModel>
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("startDate")]
        public DateTime EventStartDate { get; set; }
        [BsonElement("endDate")]
        public DateTime EventEndDate { get; set; }

        /// <summary>
        /// Get or set the address line of its 
        /// </summary>
        [BsonElement("address")]
        public string AddressLine { get; set; }
        [BsonElement("address2")]
        public string SecondAddressLine { get; set; }
        [BsonElement("address3")]
        public string ThirdAddressLine { get; set; }

        /// <summary>
        /// Get or set the city of its 
        /// </summary>
        [BsonElement("city")]
        public string City { get; set; }

        /// <summary>
        /// Get or set the state or province of the governing body
        /// </summary>
        [BsonElement("state")]
        public string StateProvince { get; set; }
        [BsonElement("primaryContact")]
        public string PrimaryContact { get; set; }
        [BsonElement("website")]
        public string EventWebsite { get; set; }
        [BsonElement("major")]
        public bool MajorEvent { get; set; }
        [BsonElement("qualifier")]
        public bool NationalTeamQualifier { get; set; }
        [BsonElement("olympicQualifier")]
        public bool OlympicQualifier { get; set; }
        [BsonElement("purse")]
        public double? TotalPurse { get; set; }
        [BsonElement("distances")]
        public IEnumerable<DistanceModel> Distances { get; set; }
        [BsonElement("governingBody")]
        public GoverningBodyPtr GoverningBody { get; set; }
    }
}
