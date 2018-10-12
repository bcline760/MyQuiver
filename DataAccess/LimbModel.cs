using MongoDB.Bson.Serialization.Attributes;

namespace MyQuiver.Model
{
    [BsonDiscriminator("Limb")]
    public class LimbModel : DbModel<LimbModel>
    {
        [BsonElement("length")]
        public string Length { get; set; }

        [BsonElement("limbMaterial")]
        public string Material { get; set; }

        /// <summary>
        /// Get or set the draw weight as set by the manufacturer
        /// </summary>
        [BsonElement("drawForce")]
        public int DrawWeight { get; set; }
    }
}
