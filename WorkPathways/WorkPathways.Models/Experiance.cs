using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WorkPathways.WorkPathways.Models
{
    public class Experiance
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid UserId { get; set; }
        public string? Role { get; set; }
        public string? CompanyName { get; set; }
        public int ProfessionalExperience { get; set; }
    }

    public class AddExperianceDto
    {
        public Guid UserId { get; set; }
        public string? Role { get; set; }
        public string? CompanyName { get; set; }
        public int ProfessionalExperience { get; set; }
    }
}
