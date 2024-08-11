using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace WorkPathways.WorkPathways.Models
{
    public class User
    {
        [BsonId]  
        [BsonRepresentation(BsonType.String)] 
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City {  get; set; }


    }
}
