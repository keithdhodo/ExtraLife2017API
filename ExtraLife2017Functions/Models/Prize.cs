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

        [BsonElement("Description")]
        [JsonProperty("description")]
        public string Description { get; set; }
        [BsonElement("Price")]
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [BsonElement("ProductCode")]
        [JsonProperty("productCode")]
        public string ProductCode { get; set; }
        [BsonElement("ProductId")]
        [JsonProperty("productId")]
        public int PrizeId { get; set; }
        [BsonElement("ProductName")]
        [JsonProperty("productName")]
        public string ProductName { get; set; }
        [BsonElement("ReleaseDate")]
        [JsonProperty("releaseDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime ReleaseDate { get; set; }
    }
}
