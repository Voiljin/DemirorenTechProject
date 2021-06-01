using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Business.Commons.Models.NewsModel
{
    public class UpdateNewsRequest
    {
        public string Id { get; set; }
        public string NewsTitle { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}
