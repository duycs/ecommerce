using ECommerce.Application.Models.Brands;
using ECommerce.Shared.Dotnet.Repositories;
using MediatR;

namespace ECommerce.Application.Read.Queries.Brands
{
    public class ListBrandsQuery : IRequest<QueryResult<BrandDto>>
    {
        public int Skip { get; private set; }
        public int Take { get; private set; }

        public ListBrandsQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }
}
