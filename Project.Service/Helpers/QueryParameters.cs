using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Helpers
{
    public class QueryParameters
    {
        //filtering
        public string FilterString { get; set; }
        public string CurrentFilter { get; set; }
        //paging

        const int maxPageSize = 7;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 5;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
        
        //sorting
        public string SortOrder { get; set; }
    }
}
