using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Common.Pagination
{
    public class PaginationRequest
    {
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 0;
        public int? searchIntValue { get; set; }
        public string? searchStringValue { get; set; }
    }
}
