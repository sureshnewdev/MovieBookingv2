using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FoodieApi.Model
{
    public class MovieTicket
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string MovieName { get; set; } = null!;

        public string BookingDeails { get; set; } = null!;
    }
}
