using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Dotnet.Repositories
{
    public static class QueryResultExtension
    {
        public static async Task<QueryResult<T>> ToQueryResultAsync<T>(this IQueryable<T> queryable, int skip, int take)
        {
            QueryResult<T> queryResult = new QueryResult<T>();
            QueryResult<T> queryResult2 = queryResult;
            queryResult2.Count = await (queryable?.CountAsync());
            QueryResult<T> queryResult3 = queryResult;
            queryResult3.Items = await (queryable?.Skip(skip)?.Take(take)?.ToListAsync());
            return queryResult;
        }
    }
}
