using DemirorenTech.Business.Commons.Models.NewsListModels;
using DemirorenTech.Business.Commons.Models.NewsModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Business.IEngines.INewsEngines
{
    public interface INewsEngine
    {
        List<NewsResponse> BulkInsertNews(InsertNewsRequest request);
        bool UpdateNews(UpdateNewsRequest request);
        List<NewsResponse> GetNewsWithIds(InsertNewsListRequest request);
    }
}
