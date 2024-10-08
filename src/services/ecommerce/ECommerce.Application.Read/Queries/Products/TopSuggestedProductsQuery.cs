using ECommerce.Application.Models.Products;
using ECommerce.Shared.Dotnet.Repositories;
using MediatR;

namespace ECommerce.Application.Read.Queries.Products
{
    public class TopSuggestedProductsQuery : IRequest<QueryResult<TopProductDto>>
    {
    }
}