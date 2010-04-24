using System.Collections.Generic;

namespace StarDestroyer.Core.Repository
{
    public class PagedSearchResult<T>
    {
        public int Count { get; set; }
        public List<T> Items { get; set; }
    }
}