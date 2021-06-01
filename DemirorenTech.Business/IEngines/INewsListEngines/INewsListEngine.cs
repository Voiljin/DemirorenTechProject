using DemirorenTech.Business.Commons.Models.NewsListModels;
using DemirorenTech.Business.Commons.Models.NewsModel;
using DemirorenTech.Mongo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Business.IEngines.INewsListEngines
{
    public interface INewsListEngine
    {
        bool InsertNewsList(InsertNewsListRequest request, List<NewsResponse> news);
        bool UpdateNewsContents(UpdateNewsRequest request);
        List<NewsListItemResponse> GetNewsListWithName(string listName, int index, int take, out int totalCount);
    }
}
