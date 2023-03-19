using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FoodieApi.Model
{
    public class Foods
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string FoodName { get; set; } = null!;

        public string FoodDesc { get; set; } = null!;
    }
}
