﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WorkPathways.WorkPathways.Models
{
    public class DesiredCompanies
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? DesiredRole { get; set; }
        public string? DesiredCompanyName { get; set; }
    }

    public class DesiredCompaniesDto
    {
        [BsonRepresentation(BsonType.String)]
        public Guid UserId { get; set; }
        public string? DesiredRole { get; set; }
        public string? DesiredCompanyName { get; set; }
    }
}
