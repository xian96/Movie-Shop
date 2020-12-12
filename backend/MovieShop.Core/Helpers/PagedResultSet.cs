using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Helpers

{
    public class PagedResultSet<T> where T: class
    {
        private object p;
        private object pageIndex;
        private int pageSize;
        private object totalCount;

        public PagedResultSet(object p, object pageIndex, int pageSize, object totalCount)
        {
            this.p = p;
            this.pageIndex = pageIndex;
            this.pageSize = pageSize;
            this.totalCount = totalCount;
        }

        public HashSet<T> set { get; set; }

    }
}
