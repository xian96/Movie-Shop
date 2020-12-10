using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Helpers
{
    public class PaginatedList<T> where T : class
    {

        public List<T> list { get; set; }
    }
}
