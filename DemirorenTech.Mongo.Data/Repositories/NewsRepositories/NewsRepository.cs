using DemirorenTech.Mongo.Data.Context;
using DemirorenTech.Mongo.Data.Entities;
using DemirorenTech.Mongo.Data.IRepositories.INewsRepositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Mongo.Data.Repositories.NewsRepositories
{
    public class NewsRepository : RepositoryBase<News>, INewsRepository
    {
        public NewsRepository(IOptions<MongoDbSettings> options) : base(options)
        {

        }
    }
}
