using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Shared.Dotnet.Repositories;
using ECommerce.Shared.Dotnet.Specifications;
using ECommerce.Shared.Dotnet.Linq;

namespace ECommerce.Shared.SeedWork
{
    public abstract class Repository<T, TDbContext> : IRepository<T> where T : class, IAggregateRoot where TDbContext : DbContext
    {
        protected TDbContext _dbContext { get; }

        protected DbSet<T> _dbSet => _dbContext.Set<T>();

        protected virtual string[] QueryInclude { get; } = new string[0];


        protected Repository(TDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentException("dbContext");
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<QueryResult<T>> QueryAsync(ISpecification<T> spec, int skip, int take, string[] sorts = null)
        {
            return await QueryInclude.Aggregate(_dbContext.Set<T>().AsQueryable(), (IQueryable<T> q, string e) => q.Include(e)).Where(spec.Predicate).SortBy(sorts ?? GetDefaultSorts())
                .ToQueryResultAsync(skip, take);
        }

        public async Task<QueryResult<T>> QueryAsync(int skip, int take, string[] sorts = null)
        {
            return await QueryInclude.Aggregate(_dbContext.Set<T>().AsQueryable(), (IQueryable<T> q, string e) => q.Include(e)).SortBy(sorts ?? GetDefaultSorts()).ToQueryResultAsync(skip, take);
        }

        public virtual Task<QueryResult<T>> SearchAsync(int skip, int take, string query, string[] sorts = null)
        {
            throw new NotImplementedException();
        }

        public async Task<QueryResult<TSubType>> QueryAsync<TSubType>(ISpecification<TSubType> spec, int skip, int take, string[] sorts = null) where TSubType : class, T
        {
            return await _dbContext.Set<T>().OfType<TSubType>().Where(spec.Predicate)
                .SortBy(sorts ?? GetDefaultSorts())
                .ToQueryResultAsync(skip, take);
        }

        public async Task<IList<T>> GetManyAsync(ISpecification<T> spec, string[] sorts = null)
        {
            return await _dbContext.Set<T>().Where(spec.Predicate).SortBy(sorts ?? GetDefaultSorts())
                .ToListAsync();
        }

        public async Task<IList<TSubType>> GetManyAsync<TSubType>(ISpecification<TSubType> spec, string[] sorts = null) where TSubType : class, T
        {
            return await _dbContext.Set<T>().OfType<TSubType>().Where(spec.Predicate)
                .SortBy(sorts ?? GetDefaultSorts())
                .ToListAsync();
        }

        public async Task<IList<T>> GetManyAsync(ISpecification<T> spec, int skip, int take, string[] sorts = null)
        {
            return await _dbContext.Set<T>().Where(spec.Predicate).SortBy(sorts ?? GetDefaultSorts())
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync(string[] sorts = null)
        {
            return await _dbContext.Set<T>().SortBy(sorts ?? GetDefaultSorts()).ToListAsync();
        }

        public async Task<IList<TSubType>> GetAllAsync<TSubType>(string[] sorts = null) where TSubType : class, T
        {
            return await _dbContext.Set<T>().OfType<TSubType>().SortBy(sorts ?? GetDefaultSorts())
                .ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(string[] sorts = null)
        {
            return await _dbContext.Set<T>().SortBy(sorts ?? GetDefaultSorts()).FirstOrDefaultAsync();
        }

        public async Task<T> GetSingleAsync(ISpecification<T> spec, string[] sorts = null)
        {
            return await _dbContext.Set<T>().SortBy(sorts ?? GetDefaultSorts()).FirstOrDefaultAsync(spec.Predicate);
        }

        public async Task<TSubType> GetSingleAsync<TSubType>(ISpecification<TSubType> spec, string[] sorts = null) where TSubType : class, T
        {
            return await _dbContext.Set<T>().OfType<TSubType>().SortBy(sorts ?? GetDefaultSorts())
                .FirstOrDefaultAsync(spec.Predicate);
        }

        public async Task<T> GetSingleAsync(params string[] sorts)
        {
            return await _dbContext.Set<T>().SortBy(sorts ?? GetDefaultSorts()).FirstOrDefaultAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid entityId)
        {
            return await _dbContext.Set<T>().FindAsync(entityId);
        }

        public async Task<TSubType> GetByIdAsync<TSubType>(Guid entityId) where TSubType : class, T
        {
            return (await _dbContext.Set<T>().FindAsync(entityId)) as TSubType;
        }

        public async Task<T> GetByIdAndReloadAsync(Guid entityId)
        {
            T entity = await GetByIdAsync(entityId);
            await ReloadAsync(entity);
            return entity;
        }

        public async Task<bool> ExistsAsync(ISpecification<T> spec)
        {
            return await _dbContext.Set<T>().AnyAsync(spec.Predicate);
        }

        public async Task<int> CountAsync<TSubType>(ISpecification<TSubType> spec) where TSubType : class, T
        {
            return await _dbContext.Set<T>().OfType<TSubType>().CountAsync(spec.Predicate);
        }

        public virtual T Add(T entity)
        {
            return _dbContext.Set<T>().Add(entity).Entity;
        }

        public virtual IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
            return entities;
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(Guid entityId)
        {
            T val = _dbContext.Set<T>().Find(entityId);
            if (val != null)
            {
                Entity entity = val as Entity;
                entity?.AddDomainEvent(new EntityDeletedDomainEvent(entity.Id, typeof(T)));
                _dbContext.Entry(val).State = EntityState.Deleted;
            }
        }

        public virtual void DeleteMany(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public async Task ReloadAsync(T entity)
        {
            EntityEntry<T> entityEntry = _dbContext.Entry(entity);
            await entityEntry.ReloadAsync();
            foreach (ReferenceEntry reference in entityEntry.References)
            {
                if (reference.TargetEntry != null)
                {
                    object[] customAttributes = reference.TargetEntry.Entity.GetType().GetCustomAttributes(typeof(OwnedAttribute), inherit: false);
                    if (customAttributes != null && customAttributes.Length != 0)
                    {
                        foreach (ReferenceEntry reference2 in reference.TargetEntry.References)
                        {
                            if (!reference2.IsLoaded)
                            {
                                await reference2.LoadAsync();
                            }
                        }

                        foreach (CollectionEntry collection in reference.TargetEntry.Collections)
                        {
                            if (!collection.IsLoaded)
                            {
                                await collection.LoadAsync();
                            }
                        }
                    }
                }

                if (!reference.IsLoaded)
                {
                    await reference.LoadAsync();
                }
            }

            foreach (CollectionEntry collection2 in entityEntry.Collections)
            {
                if (!collection2.IsLoaded)
                {
                    await collection2.LoadAsync();
                }
            }
        }

        protected virtual string[] GetDefaultSorts()
        {
            return null;
        }

        public async Task<int> CountAllAsync()
        {
            return await _dbContext.Set<T>().CountAsync();
        }

        public IQueryable<T> Queryable(ISpecification<T> specification)
        {
            return _dbContext.Set<T>().Where(specification.Predicate);
        }

        public IQueryable<T> Queryable(ISpecification<T> specification, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _dbContext.Set<T>().Where(specification.Predicate);
            if (includes != null)
            {
                foreach (Expression<Func<T, object>> navigationPropertyPath in includes)
                {
                    queryable = queryable.Include(navigationPropertyPath);
                }
            }

            return queryable;
        }

        public async Task<IList<T>> GetManyAsync(int skip, int take, string[] sorts = null)
        {
            return await _dbContext.Set<T>().SortBy(sorts ?? GetDefaultSorts()).Skip(skip)
                .Take(take)
                .ToListAsync();
        }
    }
}
