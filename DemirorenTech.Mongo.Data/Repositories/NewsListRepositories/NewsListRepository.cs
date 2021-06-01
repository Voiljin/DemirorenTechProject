using DemirorenTech.Mongo.Data.Context;
using DemirorenTech.Mongo.Data.Entities;
using DemirorenTech.Mongo.Data.IRepositories.INewsListRepositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Mongo.Data.Repositories.NewsListRepositories
{
    public class NewsListRepository : RepositoryBase<NewsList>, INewsListRepository
    {
        public NewsListRepository(IOptions<MongoDbSettings> options) : base(options)
        {

        }
    }
}
