using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AddressInfoRepository.Entities
{
    public class AddressInfo
    {
        [BsonId]
        public ObjectId Id { get; set; } = new ObjectId();

        [BsonElement("Street")]
        public string Street { get; set; }

        [BsonElement("Neighborhood")]
        public string Neighborhood { get; set; }

        [BsonElement("CEP")]
        public string CEP { get; set; }

        [BsonElement("State")]
        public string State { get; set; }
    }
}
