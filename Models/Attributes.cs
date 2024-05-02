using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class Attributes
    {
        [BsonElement("strength")]
        public int Str { get; set; } = 0;
        [BsonElement("dexterity")]
        public int Dex { get; set; } = 0;
        [BsonElement("constitution")]
        public int Con { get; set; } = 0;
        [BsonElement("intelligence")]
        public int Int { get; set; } = 0;
        [BsonElement("wisdom")]
        public int Wis { get; set; } = 0;
        [BsonElement("charisma")]
        public int Cha { get; set; } = 0;
    }
}