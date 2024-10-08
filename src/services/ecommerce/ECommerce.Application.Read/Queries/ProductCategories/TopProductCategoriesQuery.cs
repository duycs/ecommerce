using ECommerce.Application.Models.ProductCategories;
using ECommerce.Shared.Dotnet.Repositories;
using MediatR;

namespace ECommerce.Application.Read.Queries.ProductCategories
{
    public class TopProductCategoriesQuery: IRequest<QueryResult<ProductCategoryDto>>
    {
        
    }
}
