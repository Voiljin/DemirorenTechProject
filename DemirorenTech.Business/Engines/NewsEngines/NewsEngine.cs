using DemirorenTech.Business.Commons.Models.NewsListModels;
using DemirorenTech.Business.Commons.Models.NewsModel;
using DemirorenTech.Business.IEngines.INewsEngines;
using DemirorenTech.Business.Mapping;
using DemirorenTech.Mongo.Data.Entities;
using DemirorenTech.Mongo.Data.IRepositories.INewsRepositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemirorenTech.Business.Engines.NewsEngines
{
    public class NewsEngine : AutoMapperService, INewsEngine
    {
        private readonly INewsRepository _newsRepository;

        public NewsEngine(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public List<NewsResponse> BulkInsertNews(InsertNewsRequest request)
        {
            List<InsertNewsRequest> insertBulkList = new List<InsertNewsRequest>();

            for (int i = 1; i < 101; i++)
            {
                insertBulkList.Add(new InsertNewsRequest
                {
                    NewsTitle = request.NewsTitle + i.ToString(),
                    Description = request.Description + i.ToString(),
                    Link = request.Link + i.ToString(),
                    CreatedDate = DateTime.Now
                });
            }

            var insertedNews = _newsRepository.InsertMany(Mapper.Map<List<News>>(insertBulkList));

            return Mapper.Map<List<NewsResponse>>(insertedNews);
        }

        public bool UpdateNews(UpdateNewsRequest request)
        {
            var updateDefinition = Builders<News>.Update
                .Set("NewsTitle", request.NewsTitle)
                .Set("Description", request.Description)
                .Set("Link", request.Link)
                .Set("UpdatedDate", DateTime.Now);

            var updatedNews = _newsRepository.Update(request.Id, updateDefinition);

            return updatedNews;
        }        

        public List<NewsResponse> GetNewsWithIds(InsertNewsListRequest request)
        {
            ObjectId[] objectIds = new ObjectId[request.News.Count];
            int counter = 0;

            foreach (var item in request.News)
            {
                objectIds[counter] = ObjectId.Parse(item.NewsId);
                counter++;
            }

            var getNews = _newsRepository.GetFilterBy(x => objectIds.Contains(x.Id));

            return Mapper.Map<List<NewsResponse>>(getNews);
        }
    }
}
