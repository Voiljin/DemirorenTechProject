using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Business.Commons.Models.NewsModel
{
    public class InsertNewsRequest
    {
        public string NewsTitle { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
