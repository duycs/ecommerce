using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Shared.Dotnet.Linq
{
    internal static class ExpressionExtensions
    {
        public static bool IsEqualTo<TExpression, TMember>(this TExpression value, TExpression other, Func<TExpression, TMember> reader)
        {
            return EqualityComparer<TMember>.Default.Equals(reader(value), reader(other));
        }

        public static bool IsEqualTo<TExpression>(this TExpression value, TExpression other, params Func<TExpression, object>[] reader)
        {
            return reader.All((Func<TExpression, object> _) => EqualityComparer<object>.Default.Equals(_(value), _(other)));
        }

        public static int GetHashCodeFor<TExpression, TProperty>(this TExpression value, TProperty prop)
        {
            return 17 * 23 + prop.GetHashCode();
        }

        public static int GetHashCodeFor<TExpression>(this TExpression value, params object[] props)
        {
            return props.Where((object prop) => prop != null).Aggregate(17, (int current, object prop) => current * 23 + prop.GetHashCode());
        }
    }
}
