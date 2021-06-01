using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Business.Commons.Models.CommonModels
{
    public class Sort
    {
        public Sort() { }
        public Sort(SortType sorting, string propertyName)
        {
            Sorting = sorting;
            PropertyName = propertyName;
        }

        public SortType Sorting { get; set; }
        public string PropertyName { get; set; }

        /// <summary>
        /// En yeni,
        /// En eski,
        /// A dan Z'ye
        /// Z den A'ya
        /// </summary>
        public enum SortType
        {
            SortDesc = 0,
            SortAsc = 1
        }
    }
}
