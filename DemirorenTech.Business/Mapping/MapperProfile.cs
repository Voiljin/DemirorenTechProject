using AutoMapper;
using DemirorenTech.Business.Commons.Models.NewsListModels;
using DemirorenTech.Business.Commons.Models.NewsModel;
using DemirorenTech.Business.Commons.Models.UserModels;
using DemirorenTech.Mongo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Business.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {            
            //Users
            CreateMap<User, UserResponse>();
            CreateMap<UserResponse, User>();
            CreateMap<InsertUserRequest, User>();

            //News
            CreateMap<InsertNewsRequest, News>();
            CreateMap<News, NewsResponse>();
            CreateMap<UpdateNewsRequest, News>();

            //NewsList
            CreateMap<NewsResponse, NewsListItem>();
            CreateMap<UpdateNewsRequest, NewsListItem>();
            CreateMap<NewsListItem, NewsListItemResponse>();

        }
    }

    public class ObjectMapper
    {
        public static IMapper Mapper
        {
            get { return mapper.Value; }
        }

        public static IConfigurationProvider Configuration
        {
            get { return config.Value; }
        }

        public static Lazy<IMapper> mapper = new Lazy<IMapper>(() =>
        {
            var mapper = new Mapper(Configuration);
            return mapper;
        });

        public static Lazy<IConfigurationProvider> config = new Lazy<IConfigurationProvider>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });

            return config;
        });
    }
}
