using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongodbPractise
{
    public class Product
    {
        [BsonId]
        public string Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
