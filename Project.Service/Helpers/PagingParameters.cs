using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Helpers
{
    public class PagingParameters : IPagingParameters
    {
        public int? PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
