using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Business.Commons.Models.NewsListModels
{
    public class InsertNewsListRequest
    {
        public string ListName { get; set; }
        public List<InsertNewsListItemRequest> News { get; set; }
    }

    public class InsertNewsListItemRequest
    {   
        public string NewsId { get; set; }
        public int OrderNumber { get; set; }
    }


}
