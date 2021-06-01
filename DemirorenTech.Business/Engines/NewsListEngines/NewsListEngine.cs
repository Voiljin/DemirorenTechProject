using DemirorenTech.Business.Commons.Models.NewsListModels;
using DemirorenTech.Business.Commons.Models.NewsModel;
using DemirorenTech.Business.IEngines.INewsListEngines;
using DemirorenTech.Business.Mapping;
using DemirorenTech.Mongo.Data.Entities;
using DemirorenTech.Mongo.Data.IRepositories.INewsListRepositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemirorenTech.Business.Engines.NewsListEngines
{
    public class NewsListEngine : AutoMapperService, INewsListEngine
    {
        private readonly INewsListRepository _newsListRepository;

        public NewsListEngine(INewsListRepository newsListRepository)
        {
            _newsListRepository = newsListRepository;
        }

        public bool InsertNewsList(InsertNewsListRequest request, List<NewsResponse> news)
        {
            var insertReq = new NewsList()
            {
                ListName = request.ListName,
                News = Mapper.Map<List<NewsListItem>>(news)
            };

            foreach (var item in insertReq.News)
            {
                var existNews = request.News.Where(x => x.NewsId == item.Id).FirstOrDefault();
                item.OrderNumber = (existNews != null) ? existNews.OrderNumber : int.MaxValue;
            }

            _newsListRepository.Insert(insertReq);            
            
            return true;
        }

        public bool UpdateNewsContents(UpdateNewsRequest request)
        {
            var updateDefinition = Builders<NewsList>.Update
                .Set("News.$.NewsTitle", request.NewsTitle)
                .Set("News.$.Description", request.Description)
                .Set("News.$.Link", request.Link);
            
            var filter = Builders<NewsList>.Filter.Eq("News.Id", request.Id);

            return _newsListRepository.UpdateMany(filter, updateDefinition);
        }

        public List<NewsListItemResponse> GetNewsListWithName(string listName, int index, int take, out int totalCount)
        {
            var getListWrapper = _newsListRepository.GetFilterBy(x => x.ListName == listName).FirstOrDefault();
            if (getListWrapper == null) throw new Exception("List is not found");


            var mappedList = Mapper.Map<List<NewsListItemResponse>>(getListWrapper.News);

            totalCount = mappedList.Count;

            return mappedList.OrderBy(x => x.OrderNumber).Skip(index * take).Take(take).ToList();
        }
    }
}
