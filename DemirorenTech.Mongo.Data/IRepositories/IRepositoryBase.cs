using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DemirorenTech.Mongo.Data.IRepositories
{
    public interface IRepositoryBase<T> where T : class
    {
        T GetById(string id);
        List<T> GetFilterBy(Expression<Func<T, bool>> filter);
        T Insert(T entity);
        List<T> InsertMany(List<T> entities);
        bool Update(string id, UpdateDefinition<T> updateReq);
        bool UpdateMany(Expression<Func<T, bool>> filter, UpdateDefinition<T> updateReq);
        bool UpdateMany(FilterDefinition<T> filter, UpdateDefinition<T> updateReq);
        T DeleteOne(Expression<Func<T, bool>> filter);
        T DeleteById(string id);
        bool DeleteMany(Expression<Func<T, bool>> filter);
    }
}
