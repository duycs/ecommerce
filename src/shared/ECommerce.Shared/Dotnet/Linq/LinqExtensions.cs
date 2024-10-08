using ECommerce.Shared.Dotnet.Specifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using ECommerce.Shared.Dotnet.Repositories;

namespace ECommerce.Shared.Dotnet.Linq
{
    public static class LinqExtensions
    {
        public static IQueryable<T> SortBy<T>(this IQueryable<T> source, params string[] sortExpression) where T : class
        {
            if (sortExpression == null || sortExpression.Length == 0)
            {
                return source;
            }

            IOrderedQueryable<T> orderedQueryable = null;
            for (int i = 0; i < sortExpression.Length; i++)
            {
                if (!string.IsNullOrEmpty(sortExpression[i]))
                {
                    string fieldName = Regex.Replace(sortExpression[i], "[\\+\\-]", string.Empty);
                    orderedQueryable = ((!sortExpression[i].StartsWith("-")) ? ((i == 0) ? source.OrderBy(fieldName) : orderedQueryable.ThenBy(fieldName)) : ((i == 0) ? source.OrderByDescending(fieldName) : orderedQueryable.ThenByDescending(fieldName)));
                }
            }

            IQueryable<T> queryable = orderedQueryable;
            return queryable ?? source;
        }

        public static IQueryable<T> SortBy<T>(this IQueryable<T> query, SortDirection sortDirection, params Expression<Func<T, object>>[] sortExpressions)
        {
            if (sortExpressions == null || sortExpressions.All((Expression<Func<T, object>> t) => t == null))
            {
                return query;
            }

            IOrderedQueryable<T> orderedQueryable = null;
            for (int i = 0; i < sortExpressions.Length; i++)
            {
                Expression<Func<T, object>> expression = sortExpressions[i];
                if (expression != null)
                {
                    orderedQueryable = ((sortDirection != SortDirection.Descending) ? ((i == 0) ? query.OrderBy(expression) : orderedQueryable?.ThenBy(expression)) : ((i == 0) ? query.OrderByDescending(expression) : orderedQueryable?.ThenByDescending(expression)));
                }
            }

            IQueryable<T> queryable = orderedQueryable;
            return queryable ?? query;
        }

        public static IQueryable<T> SortBy<T>(this IQueryable<T> query, SortDirection sortDirection, IEnumerable<Expression<Func<T, object>>> sortExpressions)
        {
            return query.SortBy(sortDirection, sortExpressions?.ToArray());
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string fieldName) where T : class
        {
            MethodCallExpression expression = GenerateMethodCall(source, "OrderBy", fieldName);
            return source.Provider.CreateQuery<T>(expression) as IOrderedQueryable<T>;
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string fieldName) where T : class
        {
            MethodCallExpression expression = GenerateMethodCall(source, "OrderByDescending", fieldName);
            return source.Provider.CreateQuery<T>(expression) as IOrderedQueryable<T>;
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string fieldName) where T : class
        {
            MethodCallExpression expression = GenerateMethodCall(source, "ThenBy", fieldName);
            return source.Provider.CreateQuery<T>(expression) as IOrderedQueryable<T>;
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string fieldName) where T : class
        {
            MethodCallExpression expression = GenerateMethodCall(source, "ThenByDescending", fieldName);
            return source.Provider.CreateQuery<T>(expression) as IOrderedQueryable<T>;
        }

        public static IEnumerable<T> SortBy<T>(this IEnumerable<T> source, params string[] sortExpression) where T : class
        {
            if (sortExpression == null || sortExpression.Length == 0)
            {
                return source;
            }

            for (int i = 0; i < sortExpression.Length; i++)
            {
                if (!string.IsNullOrEmpty(sortExpression[i]))
                {
                    string name = Regex.Replace(sortExpression[i], "[\\+\\-]", string.Empty);
                    PropertyDescriptor sortProperty = TypeDescriptor.GetProperties(typeof(T)).Find(name, ignoreCase: true);
                    source = ((!sortExpression[i].StartsWith("-")) ? source.OrderBy((T a) => sortProperty.GetValue(a)).ToList() : source.OrderByDescending((T a) => sortProperty.GetValue(a)).ToList());
                }
            }

            return source;
        }

        public static MethodCallExpression GenerateMethodCall<T>(IQueryable<T> source, string methodName, string fieldName) where T : class
        {
            Type typeFromHandle = typeof(T);
            Type resultType;
            LambdaExpression expression = GenerateSelector<T>(fieldName, out resultType);
            return Expression.Call(typeof(Queryable), methodName, new Type[2] { typeFromHandle, resultType }, source.Expression, Expression.Quote(expression));
        }

        public static Expression<Func<T, bool>> OrElse<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            if (second == null)
            {
                return first;
            }

            return first.Compose(second, Expression.OrElse);
        }

        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            if (second == null)
            {
                return first;
            }

            return first.Compose(second, Expression.AndAlso);
        }

        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> predicate)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Not(predicate.Body), new ParameterExpression[1] { predicate.Parameters[0] });
        }

        public static Expression<Func<T, bool>> Compose<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, Func<Expression, Expression, Expression> merge)
        {
            if (first.IsEquals((T t) => true))
            {
                return second;
            }

            if (second.IsEquals((T t) => true))
            {
                return first;
            }

            return first.ComposeExpression(second, merge);
        }

        public static Expression<T> ComposeExpression<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            if (first.IsEquals(second))
            {
                return first;
            }

            Expression arg = ParameterRebinder.ReplaceParameters(first.Parameters.Select((ParameterExpression f, int i) => new
            {
                f = f,
                s = second.Parameters[i]
            }).ToDictionary(p => p.s, p => p.f), second.Body);
            return Expression.Lambda<T>(merge(first.Body, arg), first.Parameters);
        }

        public static Specification<T> ToSpec<T>(this Expression<Func<T, bool>> expression)
        {
            return new Specification<T>(expression);
        }

        private static LambdaExpression GenerateSelector<T>(string propertyName, out Type resultType) where T : class
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "Entity");
            PropertyInfo property;
            Expression expression;
            if (propertyName.Contains('.'))
            {
                string[] array = propertyName.Split('.');
                property = typeof(T).GetProperty(array[0], BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                expression = Expression.MakeMemberAccess(parameterExpression, property);
                for (int i = 1; i < array.Length; i++)
                {
                    property = property.PropertyType.GetProperty(array[i], BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                    expression = Expression.MakeMemberAccess(expression, property);
                }
            }
            else
            {
                property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                expression = Expression.MakeMemberAccess(parameterExpression, property);
            }

            resultType = property.PropertyType;
            return Expression.Lambda(expression, parameterExpression);
        }

        public static IEnumerable<IEnumerable<TSource>> FetchInChunk<TSource>(this IQueryable<TSource> source, int chunkSize)
        {
            int iter = 0;
            while (true)
            {
                List<TSource> list = source.Skip(iter).Take(chunkSize).ToList();
                if (list.Any())
                {
                    iter += chunkSize;
                    yield return list;
                    continue;
                }

                break;
            }
        }

        public static IEnumerable<TSource> TakeOneByOne<TSource>(this IQueryable<TSource> source, int prefetch = 10)
        {
            int iter = 0;
            while (true)
            {
                List<TSource> list = source.Skip(iter).Take(prefetch).ToList();
                if (!list.Any())
                {
                    break;
                }

                iter += list.Count;
                foreach (TSource item in list)
                {
                    yield return item;
                }
            }
        }
    }
}
