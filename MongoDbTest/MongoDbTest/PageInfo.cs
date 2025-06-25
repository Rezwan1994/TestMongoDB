using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbTest
{
    public class PageInfo
    {

        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("answerKeyURL")]
        public string AnswerKeyURL { get; set; }

        [BsonElement("page")]
        public string Page { get; set; }

        [BsonElement("pageId")]
        public int PageId { get; set; }

        [BsonElement("receiver")]
        public int Receiver { get; set; }

        [BsonElement("roomId")]
        public string RoomId { get; set; }

        [BsonElement("sender")]
        public int Sender { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
