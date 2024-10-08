using ECommerce.Shared.Dotnet.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.Dotnet.Specifications
{
    public class AndSpecification<T> : Specification<T>
    {
        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
            : base(left.Predicate.AndAlso(right.Predicate))
        {
        }
    }
}
