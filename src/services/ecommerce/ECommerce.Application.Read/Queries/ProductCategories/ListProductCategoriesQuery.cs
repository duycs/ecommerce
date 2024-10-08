using ECommerce.Application.Models.ProductCategories;
using ECommerce.Shared.Dotnet.Repositories;
using MediatR;

namespace ECommerce.Application.Read.Queries.ProductCategories
{
    public class ListProductCategoriesQuery : IRequest<QueryResult<ProductCategoryDto>>
    {
        public int Skip { get; private set; }
        public int Take { get; private set; }

        public ListProductCategoriesQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }
}
