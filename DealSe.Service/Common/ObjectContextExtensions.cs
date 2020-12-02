using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DealSe.Service.Common
{
    public static class ObjectContextExtensions
    {
        /// <summary>
        /// Searches in all string properties for the specifed search key.
        /// It is also able to search for several words. If the searchKey is for example 'John Travolta' then
        /// with exactMatch set to false all records which contain either 'John' or 'Travolta' in some string property
        /// are returned.
        /// </summary>
        /// <param name="query">Base query for the search.</param>
        /// <param name="searchKey">Search term.</param>
        /// <param name="exactMatch">Specifies if only the whole word or every single word should be searched.</param>
        /// <param name="searchProperties">Properties to check for matches.</param>
        /// <returns>Query that matches specified search parameters.</returns>

        public static IQueryable<T> FullTextSearch<T>(this IQueryable<T> list, string searchKey, string[] dtsearch, bool exactMatch = true, params string[] searchProperties)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "c");
            MethodInfo containsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
            var publicProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(p => p.PropertyType == typeof(string));
            Expression orExpressions = null;

            var data = publicProperties.Where(a => !dtsearch.Contains(a.Name.ToLower()));

            foreach (var callContainsMethod in from property in data
                                               let myProperty = Expression.Property(parameter, property.Name)
                                               let myExpression = Expression.Call(Expression.Call(myProperty, typeof(string).GetMethod("ToLower", new Type[] { })), "Contains", null, Expression.Constant(searchKey))
                                               let myNullExp = Expression.Call(typeof(string), (typeof(string).GetMethod("IsNullOrEmpty")).Name, null, myProperty)
                                               let myNotExp = Expression.Not(myNullExp)
                                               select new { myExpression, myNotExp })
            {
                var andAlso = Expression.AndAlso(callContainsMethod.myNotExp, callContainsMethod.myExpression);
                if (orExpressions == null)
                {
                    orExpressions = andAlso;
                }
                else
                {
                    orExpressions = Expression.Or(orExpressions, andAlso);
                }
            }

            IQueryable<T> queryable = list.AsQueryable<T>();
            MethodCallExpression whereCallExpression = Expression.Call(
                typeof(Queryable),
                "Where",
                new Type[] { queryable.ElementType },
                queryable.Expression,
                Expression.Lambda<Func<T, bool>>(orExpressions, new ParameterExpression[] { parameter }));


            var results = queryable.Provider.CreateQuery<T>(whereCallExpression);
            return results;
        }


    }
}
