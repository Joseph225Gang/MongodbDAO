using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongodbPractise
{
    public class ProductDao
    {
        private MongoClient _mongoClient;
        private IMongoDatabase _db;
        private IMongoCollection<Product> _products;

        public ProductDao()
        {
            _mongoClient = new MongoClient();
            _db = _mongoClient.GetDatabase("test");
            _products = _db.GetCollection<Product>("Products");
        }

        public async Task<List<Product>> QueryAll()
        {
            return await _products.Find(new BsonDocument()).ToListAsync();
        }

        public void Insert(Product product)
        {
            _products.InsertOne(product);
        }

        public void Update(Product product)
        {
            var filter = Builders<Product>.Filter.Eq("_id", 10);
            var update = Builders<Product>.Update.Set("_id", product.Id);
            _products.UpdateOne(filter, update);
        }

        public long Delete(string id)
        {
            var filter = Builders<Product>.Filter.Eq("_id", id);
            var result = _products.DeleteOne(filter);
            return result.DeletedCount;
        }
    }
}
