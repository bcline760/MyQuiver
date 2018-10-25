using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MyQuiver.Model
{
    [BsonIgnoreExtraElements]
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(UserModel), typeof(ArcheryEventModel),
                    typeof(OrganizationModel), typeof(GoverningBodyModel),
                    typeof(LimbModel), typeof(GoverningBodyPtr))]
    public abstract class DbModel<T> where T : class
    {
        public DbModel()
        {
        }

        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
        [BsonElement("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
        [BsonElement("updatedBy")]
        public string UpdatedBy { get; set; }
        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }
    }
}
