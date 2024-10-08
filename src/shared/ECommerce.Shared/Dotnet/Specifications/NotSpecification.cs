using ECommerce.Shared.Dotnet.Linq;

namespace ECommerce.Shared.Dotnet.Specifications
{
    public class NotSpecification<T> : Specification<T>
    {
        public NotSpecification(ISpecification<T> spec)
            : base(spec.Predicate.Not())
        {
        }
    }
}
