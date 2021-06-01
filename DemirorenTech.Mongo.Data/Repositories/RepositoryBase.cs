using DemirorenTech.Mongo.Data.Context;
using DemirorenTech.Mongo.Data.IRepositories;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DemirorenTech.Mongo.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<T> _collection;

        public RepositoryBase(IOptions<MongoDbSettings> settings)
        {
            _context = new MongoDbContext(settings);
            _collection = _context.GetCollection<T>();
        }

        public T GetById(string id)
        {
            var objectId = ObjectId.Parse(id);
            return _collection.Find(Builders<T>.Filter.Eq("_id", objectId)).FirstOrDefault();
        }

        public List<T> GetFilterBy(Expression<Func<T, bool>> filter)
        {
            return _collection.Find(filter).ToList();
        }

        public T Insert(T entity)
        {
            _collection.InsertOne(entity);
            return entity;
        }

        public List<T> InsertMany(List<T> entities)
        {
            _collection.InsertMany(entities);
            return entities;
        }

        public bool Update(string id, UpdateDefinition<T> updateReq)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<T>.Filter.Eq("_id", objectId);

            var update = _collection.UpdateOne(filter, updateReq);

            return update.IsAcknowledged;
        }

        public bool UpdateMany(Expression<Func<T, bool>> filter, UpdateDefinition<T> updateReq)
        {
            var update = _collection.UpdateMany(filter, updateReq);

            return update.IsAcknowledged;
        }

        public bool UpdateMany(FilterDefinition<T> filter, UpdateDefinition<T> updateReq)
        {
            var update = _collection.UpdateMany(filter, updateReq);

            return update.IsAcknowledged;
        }

        public T DeleteOne(Expression<Func<T, bool>> filter)
        {
            return _collection.FindOneAndDelete(filter);
        }

        public T DeleteById(string id)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<T>.Filter.Eq("_id", objectId);
            return _collection.FindOneAndDelete(filter);
        }

        public bool DeleteMany(Expression<Func<T, bool>> filter)
        {
            _collection.DeleteMany(filter);

            return true;
        }
        
    }
}
