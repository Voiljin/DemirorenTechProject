using DemirorenTech.Mongo.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Business.ConfigureMongoDbSettings
{
    public static class MongoDbSettingsExtension
    {
        public static IServiceCollection AddMongoDbSettings(this IServiceCollection services, IConfiguration configuration)
        {
            return services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = configuration.GetSection("ConnectionStrings:DefaultConnectionString").Value;
                options.Database = configuration.GetSection("ConnectionStrings:DbName").Value;
            });
        }
    }
}
