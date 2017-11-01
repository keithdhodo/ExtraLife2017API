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

        [BsonElement("PrizeId")]
        [JsonProperty("prizeId")]
        public int PrizeId { get; set; }

        [BsonElement("DateToDisplay")]
        [JsonProperty("dateToDisplay")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DateToDisplay { get; set; }

        [BsonElement("DateAdded")]
        [JsonProperty("dateAdded")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DateAdded { get; set; }

        [BsonElement("PrizeName")]
        [JsonProperty("prizeName")]
        public string PrizeName { get; set; }

        [BsonElement("Donor")]
        [JsonProperty("donor")]
        public string Donor { get; set; }

        [BsonElement("Tier")]
        [JsonProperty("tier")]
        public int Tier { get; set; }

        [BsonElement("Notes")]
        [JsonProperty("notes")]
        public string Notes { get; set; }

        [BsonElement("Restriction")]
        [JsonProperty("restriction")]
        public string Restriction { get; set; }

        [BsonElement("WonBy")]
        [JsonProperty("wonBy")]
        public string WonBy { get; set; }
    }
}
