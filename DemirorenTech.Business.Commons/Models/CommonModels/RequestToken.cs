using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Business.Commons.Models.CommonModels
{
    public class RequestToken<T>
    {
        
        public Paging Paging { get; set; }

        
        public T Filter { get; set; }

        
        public Sort Sorting { get; set; }


    }
}
