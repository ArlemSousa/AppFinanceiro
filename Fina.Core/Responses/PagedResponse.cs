using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Responses
{
    public class PagedResponse<Tdata> : Response<Tdata>
    {
        public int CurrentPage { get; set; }
        public int Totalpages => (int)Math.Ceiling(TotalCount / (double)PageSize );
        public int PageSize { get; set; } = Configuration.DefaultPageSize;
        public int TotalCount { get; set; }
    }
}
