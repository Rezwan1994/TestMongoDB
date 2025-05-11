using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbTest
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
