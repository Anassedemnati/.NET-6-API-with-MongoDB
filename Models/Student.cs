using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_with_MongoDb.Models
{
    [BsonIgnoreExtraElements]
    public class Student
       {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; }=string.Empty;
        [BsonElement("graduated")]
        public bool IsGraduated { get; set; }
        [BsonElement("courses")]
        public string[]? Courses { get; set; }
        [BsonElement("gender")]
        public string Gender { get; set; }
        [BsonElement("age")]
        public int Age { get; set; }
    }
}
