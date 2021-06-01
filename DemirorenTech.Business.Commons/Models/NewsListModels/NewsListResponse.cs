using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Business.Commons.Models.NewsListModels
{
    public class NewsListResponse
    {
        public string Id { get; set; }
        public string ListName { get; set; }
        public List<NewsListItemResponse> News { get; set; }
    }

    public class NewsListItemResponse
    {
        
        public string Id { get; set; }
        
        public string NewsTitle { get; set; }
        
        public string Description { get; set; }
        
        public string Link { get; set; }
        
        public int OrderNumber { get; set; }
    }
}
