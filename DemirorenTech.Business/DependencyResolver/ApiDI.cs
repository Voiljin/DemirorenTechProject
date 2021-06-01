using DemirorenTech.Mongo.Data.IRepositories.INewsRepositories;
using DemirorenTech.Mongo.Data.Repositories.NewsRepositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using DemirorenTech.Mongo.Data.IRepositories.IUserRepositories;
using DemirorenTech.Mongo.Data.Repositories.UserRepositories;
using DemirorenTech.Business.Engines.UserEngines;
using DemirorenTech.Business.IEngines.IUserEngines;
using DemirorenTech.Business.Engines.NewsEngines;
using DemirorenTech.Business.IEngines.INewsEngines;
using DemirorenTech.Mongo.Data.Repositories.NewsListRepositories;
using DemirorenTech.Mongo.Data.IRepositories.INewsListRepositories;
using DemirorenTech.Business.Engines.NewsListEngines;
using DemirorenTech.Business.IEngines.INewsListEngines;

namespace DemirorenTech.Business.DependencyResolver
{
    public static class ApiDI
    {
        public static IServiceCollection RegisterServicesForApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserEngine, UserEngine>();


            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<INewsEngine, NewsEngine>();

            services.AddScoped<INewsListRepository, NewsListRepository>();
            services.AddScoped<INewsListEngine, NewsListEngine>();

            return services;
        }
    }
}
