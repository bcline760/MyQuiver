using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyQuiver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyQuiver.Model
{
    [BsonDiscriminator("User")]
    public class UserModel : DbModel<UserModel>
    {
        [BsonElement("type"),BsonRequired]
        public string Type { get; set; }
        [BsonElement("status"), BsonRequired]
        public string Status { get; set; }
        [BsonElement("provider"), BsonRequired]
        public string Provider { get; set; }
        [BsonElement("ptoken")]
        public string ProviderToken { get; set; }

        [BsonElement("fname"), BsonRequired]
        public string FirstName { get; set; }

        [BsonElement("lname"), BsonRequired]
        public string LastName { get; set; }

        [BsonElement("pemail"),BsonRequired]
        public string PrimaryEmail { get; set; }

        [BsonElement("state"), BsonRequired]
        public string State { get; set; }

        [BsonElement("pcode")]
        public string PostalCode { get; set; }

        [BsonElement("age")]
        public int? Age { get; set; }

        [BsonElement("style")]
        public string PreferredStyle { get; set; }
    }
}
