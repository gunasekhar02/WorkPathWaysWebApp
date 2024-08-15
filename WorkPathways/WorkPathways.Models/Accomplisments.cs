using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WorkPathways.WorkPathways.Models
{
    public class Accomplisments
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public string? Awards { get; set; }
        public string? InCompany { get; set; }
        public string? AwardedFor { get; set; }

    }
}
