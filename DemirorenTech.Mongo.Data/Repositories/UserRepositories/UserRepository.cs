using DemirorenTech.Mongo.Data.Context;
using DemirorenTech.Mongo.Data.Entities;
using DemirorenTech.Mongo.Data.IRepositories.IUserRepositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Mongo.Data.Repositories.UserRepositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IOptions<MongoDbSettings> options) : base(options)
        {

        }
    }
}
