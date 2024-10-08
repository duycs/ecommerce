using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Shared.Helpers.Utils
{
    public class AsyncIterator<T>
    {
        private readonly Func<int, int, Task<IEnumerable<T>>> _query;

        private int skip;

        private int _take;

        private List<T> _value;

        public AsyncIterator(Func<int, int, Task<IEnumerable<T>>> query, int chunkSize = 10)
        {
            _query = query;
            _take = chunkSize;
        }

        private async Task<bool> Next(CancellationToken cancellationToken = default(CancellationToken))
        {
            IEnumerable<T> enumerable = await _query(skip, _take);
            if (enumerable == null || !enumerable.Any())
            {
                return false;
            }

            skip += _take;
            _value = enumerable.ToList();
            return true;
        }

        public async Task ForEach(Func<T, Task> selector, CancellationToken cancellationToken = default(CancellationToken))
        {
            while (await Next(cancellationToken))
            {
                foreach (T item in _value)
                {
                    await selector(item);
                }
            }
        }

        public async Task ForEach(Action<T> selector, CancellationToken cancellationToken = default(CancellationToken))
        {
            while (await Next(cancellationToken))
            {
                foreach (T item in _value)
                {
                    selector(item);
                }
            }
        }

        public async Task ForChunk(Func<IEnumerable<T>, Task> selector, CancellationToken cancellationToken = default(CancellationToken))
        {
            while (await Next(cancellationToken))
            {
                await selector(_value);
            }
        }

        public async Task ForChunk(Action<IEnumerable<T>> selector, CancellationToken cancellationToken = default(CancellationToken))
        {
            while (await Next(cancellationToken))
            {
                selector(_value);
            }
        }

        public static AsyncIterator<T> From(Func<int, int, Task<IEnumerable<T>>> query)
        {
            return new AsyncIterator<T>(query);
        }

        public static AsyncIterator<T> From(IQueryable<T> queryable)
        {
            return new AsyncIterator<T>(async (int skip, int take) => await queryable.Skip(skip).Take(take).ToListAsync());
        }

        public AsyncIterator<T> WithChunkSize(int chunkSize)
        {
            _take = chunkSize;
            return this;
        }
    }
}
