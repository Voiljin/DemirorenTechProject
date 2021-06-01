using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Mongo.Data.Entities
{
    public class News
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("NewsTitle")]
        public string NewsTitle { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Link")]
        public string Link { get; set; }

        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [BsonElement("UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }
    }
}
