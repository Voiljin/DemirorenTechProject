using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Mongo.Data.Entities
{
    public class NewsList
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("ListName")]
        public string ListName { get; set; }

        public List<NewsListItem> News { get; set; }
    }

    public class NewsListItem
    {
        [BsonElement("Id")]
        public string Id { get; set; }

        [BsonElement("NewsTitle")]
        public string NewsTitle { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Link")]
        public string Link { get; set; }

        [BsonElement("OrderNumber")]
        public int OrderNumber { get; set; }
    }
}
