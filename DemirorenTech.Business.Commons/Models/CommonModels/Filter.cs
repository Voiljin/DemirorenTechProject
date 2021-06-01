using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Business.Commons.Models.CommonModels
{
    public sealed class Filter<T>
    {
        private static readonly Filter<T> instance = new Filter<T>();
        private Filter() { }
        public static Filter<T> Instance
        {
            get
            {
                return instance;
            }
        }

        public RequestToken<T> Parameter(RequestToken<T> filterParameter)
        {
            return filterParameter;
        }
        public RequestToken<T> Parameter(RequestToken<T> filterParameter, int totalRecordCount)
        {
            if (filterParameter.Paging == null)
            {
                filterParameter.Paging = new Paging();
            }
            var pageList = filterParameter.Paging.PagingList(filterParameter, totalRecordCount);
            return filterParameter;
        }
    }
}
