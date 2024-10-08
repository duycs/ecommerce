using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Shared.Dotnet.Repositories
{
    public class QueryResult<T>
    {
        public long Count { get; set; }

        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();


        public QueryResult()
        {
        }

        public QueryResult(long count, IEnumerable<T> items)
        {
            Count = count;
            Items = items;
        }

        public static QueryResult<T> Empty()
        {
            return new QueryResult<T>(0L, null);
        }
    }
}
