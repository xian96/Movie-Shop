using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Helpers

{
    public class PagedResultSet<T> where T: class
    {
        public HashSet<T> set { get; set; }

    }
}
