using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Shared.Dotnet.Repositories;
using ECommerce.Shared.Dotnet.Specifications;

namespace ECommerce.Shared.SeedWork
{
    public interface IAggregateRoot
    {
    }
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task CommitAsync();

        Task<QueryResult<T>> QueryAsync(ISpecification<T> spec, int skip, int take, string[] sorts = null);

        Task<QueryResult<T>> QueryAsync(int skip, int take, string[] sorts = null);

        Task<QueryResult<T>> SearchAsync(int skip, int take, string query, string[] sorts = null);

        Task<QueryResult<TSubType>> QueryAsync<TSubType>(ISpecification<TSubType> spec, int skip, int take, string[] sorts = null) where TSubType : class, T;

        Task<IList<T>> GetManyAsync(ISpecification<T> spec, string[] sorts = null);

        Task<IList<T>> GetManyAsync(int skip, int take, string[] sorts = null);

        Task<IList<T>> GetManyAsync(ISpecification<T> spec, int skip, int take, string[] sorts = null);

        Task<IList<TSubType>> GetManyAsync<TSubType>(ISpecification<TSubType> spec, string[] sorts = null) where TSubType : class, T;

        Task<IList<T>> GetAllAsync(string[] sorts = null);

        Task<IList<TSubType>> GetAllAsync<TSubType>(string[] sorts = null) where TSubType : class, T;

        Task<T> FirstOrDefaultAsync(string[] sorts = null);

        Task<T> GetSingleAsync(ISpecification<T> spec, string[] sorts = null);

        Task<TSubType> GetSingleAsync<TSubType>(ISpecification<TSubType> spec, string[] sorts = null) where TSubType : class, T;

        Task<T> GetSingleAsync(params string[] sorts);

        Task<T> GetByIdAsync(Guid entityId);

        Task<TSubType> GetByIdAsync<TSubType>(Guid entityId) where TSubType : class, T;

        Task<T> GetByIdAndReloadAsync(Guid entityId);

        Task<bool> ExistsAsync(ISpecification<T> spec);

        Task<int> CountAsync<TSubType>(ISpecification<TSubType> spec) where TSubType : class, T;

        T Add(T entity);

        IEnumerable<T> AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void Delete(T entity);

        void Delete(Guid entityId);

        void DeleteMany(IEnumerable<T> entities);

        Task ReloadAsync(T entity);

        Task<int> CountAllAsync();

        IQueryable<T> Queryable(ISpecification<T> specification);

        IQueryable<T> Queryable(ISpecification<T> specification, params Expression<Func<T, object>>[] includes);
    }
}
