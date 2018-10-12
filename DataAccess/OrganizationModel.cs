using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;

namespace MyQuiver.Model
{
    [BsonDiscriminator("Organization")]
    public class OrganizationModel : DbModel<OrganizationModel>
    {
        [BsonElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Get or set the address line of its 
        /// </summary>
        [BsonElement("addr")]
        public string AddressLine { get; set; }
        [BsonElement("addr2")]
        public string SecondAddressLine { get; set; }
        [BsonElement("addr3")]
        public string ThirdAddressLine { get; set; }

        /// <summary>
        /// Get or set the city of its 
        /// </summary>
        [BsonElement("city")]
        public string City { get; set; }

        /// <summary>
        /// Get or set the state or province of the governing body
        /// </summary>
        [BsonElement("province")]
        public string StateProvince { get; set; }
        [BsonElement("postalCode")]
        public string PostalCode { get; set; }
        [BsonElement("website")]
        public string Website { get; set; }
        [BsonElement("logo")]
        public string LogoPath { get; set; }
        [BsonElement("membershipRequired")]
        public bool MembershipRequired { get; set; }
        /// <summary>
        /// Get or set the governing body this organization belongs
        /// </summary>
        [BsonElement("g_body")]
        public GoverningBodyModel GoverningBody { get; set; }
    }
}
