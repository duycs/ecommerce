using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce.Shared.Dotnet.Linq
{
    internal sealed class ExpressionCollection : ExpressionVisitor, IExpressionCollection, IEnumerable<Expression>, IEnumerable
    {
        private readonly Expression _root;

        private readonly ICollection<Expression> _expressions = new List<Expression>();

        public ExpressionCollection(Expression expression)
        {
            _root = expression;
        }

        public IEnumerator<Expression> GetEnumerator()
        {
            return _expressions.GetEnumerator();
        }

        public void Fill()
        {
            Visit(_root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override Expression Visit(Expression node)
        {
            if (node != null)
            {
                _expressions.Add(node);
            }

            return base.Visit(node);
        }
    }
}
