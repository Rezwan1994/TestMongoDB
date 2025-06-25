using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace MongoDbTest
{
    public class DrowInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)] 
        public Guid Id { get; set; }

        [BsonElement("bookPageId")]
        public int BookPageId { get; set; }

        [BsonElement("image")]
        public byte[] Image { get; set; }

        [BsonElement("roomId")]
        public string RoomId { get; set; }

        [BsonElement("strokeData")]
        public List<StrokeData> StrokeData { get; set; }

        [BsonElement("receiver")]
        public int Receiver { get; set; }

        [BsonElement("sender")]
        public int Sender { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }
    }

    public class StrokePoint
    {
        [BsonElement("azimuth")]
        public double Azimuth { get; set; }

        [BsonElement("force")]
        public double Force { get; set; }

        [BsonElement("opacity")]
        public double Opacity { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }

        [BsonElement("x")]
        public double X { get; set; }

        [BsonElement("y")]
        public double Y { get; set; }

        [BsonElement("altitude")]
        public double Altitude { get; set; }
    }

    public class StrokeData
    {
        [BsonElement("strokeWidth")]
        public double StrokeWidth { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }

        [BsonElement("strokePoints")]
        public List<StrokePoint> StrokePoints { get; set; }

        [BsonElement("strokeColor")]
        public string StrokeColor { get; set; }
        [BsonElement("strokeInkType")]
        public string StrokeInkType { get; set; }
    }
}
