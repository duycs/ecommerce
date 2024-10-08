using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce.Shared.Dotnet.Linq
{
    internal interface IExpressionCollection : IEnumerable<Expression>, IEnumerable
    {
        void Fill();
    }
    internal sealed class ExpressionValueComparer : ExpressionVisitor, IValueComparer<Expression>
    {
        private Queue<Expression> _tracked;

        private Expression _current;

        private bool _eq = true;

        public bool Compare(Expression x, Expression y)
        {
            IExpressionCollection expressionCollection = new ExpressionCollection(y);
            expressionCollection.Fill();
            _tracked = new Queue<Expression>(expressionCollection);
            Visit(x);
            return _eq;
        }

        public override Expression Visit(Expression node)
        {
            if (!_eq)
            {
                return node;
            }

            if (node == null || _tracked.Count == 0)
            {
                _eq = false;
                return node;
            }

            Expression expression = _tracked.Peek();
            if (expression == null || expression.NodeType != node.NodeType || expression.Type != node.Type)
            {
                _eq = false;
                return node;
            }

            _current = _tracked.Dequeue();
            return base.Visit(node);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            BinaryExpression other = (BinaryExpression)_current;
            _eq &= node.IsEqualTo(other, (BinaryExpression _) => _.Method, (BinaryExpression _) => _.IsLifted, (BinaryExpression _) => _.IsLiftedToNull);
            if (!_eq)
            {
                return node;
            }

            return base.VisitBinary(node);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            ConstantExpression other = (ConstantExpression)_current;
            _eq &= node.IsEqualTo(other, (ConstantExpression _) => _.Value);
            if (!_eq)
            {
                return node;
            }

            return base.VisitConstant(node);
        }

        protected override Expression VisitDebugInfo(DebugInfoExpression node)
        {
            DebugInfoExpression other = (DebugInfoExpression)_current;
            _eq &= node.IsEqualTo(other, (DebugInfoExpression _) => _.EndColumn, (DebugInfoExpression _) => _.EndLine, (DebugInfoExpression _) => _.IsClear, (DebugInfoExpression _) => _.StartLine, (DebugInfoExpression _) => _.StartColumn);
            if (!_eq)
            {
                return node;
            }

            return base.VisitDebugInfo(node);
        }

        protected override Expression VisitGoto(GotoExpression node)
        {
            GotoExpression other = (GotoExpression)_current;
            _eq &= node.IsEqualTo(other, (GotoExpression _) => _.Kind, (GotoExpression _) => _.Target);
            if (!_eq)
            {
                return node;
            }

            return base.VisitGoto(node);
        }

        protected override Expression VisitIndex(IndexExpression node)
        {
            IndexExpression other = (IndexExpression)_current;
            _eq &= node.IsEqualTo(other, (IndexExpression _) => _.Indexer);
            if (!_eq)
            {
                return node;
            }

            return base.VisitIndex(node);
        }

        protected override Expression VisitLabel(LabelExpression node)
        {
            LabelExpression other = (LabelExpression)_current;
            _eq &= node.IsEqualTo(other, (LabelExpression _) => _.Target);
            if (!_eq)
            {
                return node;
            }

            return base.VisitLabel(node);
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            LambdaExpression other = (LambdaExpression)_current;
            _eq &= node.IsEqualTo(other, (LambdaExpression _) => _.Name, (LambdaExpression _) => _.TailCall);
            if (!_eq)
            {
                return node;
            }

            return base.VisitLambda(node);
        }

        protected override Expression VisitListInit(ListInitExpression node)
        {
            ListInitExpression other = (ListInitExpression)_current;
            _eq &= node.IsEqualTo(other, (ListInitExpression _) => _.Initializers);
            if (!_eq)
            {
                return node;
            }

            return base.VisitListInit(node);
        }

        protected override Expression VisitLoop(LoopExpression node)
        {
            LoopExpression other = (LoopExpression)_current;
            _eq &= node.IsEqualTo(other, (LoopExpression _) => _.BreakLabel, (LoopExpression _) => _.ContinueLabel);
            if (!_eq)
            {
                return node;
            }

            return base.VisitLoop(node);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            MemberExpression other = (MemberExpression)_current;
            _eq &= node.IsEqualTo(other, (MemberExpression _) => _.Member);
            if (!_eq)
            {
                return node;
            }

            return base.VisitMember(node);
        }

        protected override Expression VisitMemberInit(MemberInitExpression node)
        {
            MemberInitExpression other = (MemberInitExpression)_current;
            _eq &= node.IsEqualTo(other, (MemberInitExpression _) => _.Bindings);
            if (!_eq)
            {
                return node;
            }

            return base.VisitMemberInit(node);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            MethodCallExpression other = (MethodCallExpression)_current;
            _eq &= node.IsEqualTo(other, (MethodCallExpression _) => _.Method);
            if (!_eq)
            {
                return node;
            }

            return base.VisitMethodCall(node);
        }

        protected override Expression VisitNew(NewExpression node)
        {
            NewExpression other = (NewExpression)_current;
            _eq &= node.IsEqualTo(other, (NewExpression _) => _.Constructor, (NewExpression _) => _.Members);
            if (!_eq)
            {
                return node;
            }

            return base.VisitNew(node);
        }

        protected override Expression VisitSwitch(SwitchExpression node)
        {
            SwitchExpression other = (SwitchExpression)_current;
            _eq &= node.IsEqualTo(other, (SwitchExpression _) => _.Comparison);
            if (!_eq)
            {
                return node;
            }

            return base.VisitSwitch(node);
        }

        protected override Expression VisitTry(TryExpression node)
        {
            TryExpression other = (TryExpression)_current;
            _eq &= node.IsEqualTo(other, (TryExpression _) => _.Handlers);
            if (!_eq)
            {
                return node;
            }

            return base.VisitTry(node);
        }

        protected override Expression VisitTypeBinary(TypeBinaryExpression node)
        {
            TypeBinaryExpression other = (TypeBinaryExpression)_current;
            _eq &= node.IsEqualTo(other, (TypeBinaryExpression _) => _.TypeOperand);
            if (!_eq)
            {
                return node;
            }

            return base.VisitTypeBinary(node);
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            UnaryExpression other = (UnaryExpression)_current;
            _eq &= node.IsEqualTo(other, (UnaryExpression _) => _.Method, (UnaryExpression _) => _.IsLifted, (UnaryExpression _) => _.IsLiftedToNull);
            if (!_eq)
            {
                return node;
            }

            return base.VisitUnary(node);
        }
    }
}
