using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace ExtraLife2017Functions.Models
{
    public class Prize
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid _id { get; set; }
        [BsonElement("DisplayDate")]
        [JsonProperty("displayDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DisplayDate { get; set; }

        [BsonElement("Description")]
        [JsonProperty("description")]
        public string Description { get; set; }
        [BsonElement("Price")]
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [BsonElement("Tier")]
        [JsonProperty("tier")]
        public string Tier { get; set; }
        [BsonElement("PrizeId")]
        [JsonProperty("prizeId")]
        public int PrizeId { get; set; }
        [BsonElement("PrizeName")]
        [JsonProperty("prizeName")]
        public string ProductName { get; set; }
        [BsonElement("DateAdded")]
        [JsonProperty("dateAdded")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DateAdded { get; set; }
        [BsonElement("WonBy")]
        [JsonProperty("wonBy")]
        public string WonBy { get; set; }
    }
}
