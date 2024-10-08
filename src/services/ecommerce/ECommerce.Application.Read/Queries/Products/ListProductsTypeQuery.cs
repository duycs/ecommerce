using ECommerce.Application.Models.Products;
using ECommerce.Shared.Dotnet.Repositories;
using MediatR;

namespace ECommerce.Application.Read.Queries.Products
{
    public class ListProductsTypeQuery: IRequest<QueryResult<TopProductDto>>
    {
        public int Skip { get; private set; }
        public int Take { get; private set; }
        public string ProductNameTable { get; private set; }
        public ListProductsTypeQuery(int skip, int take, string productNameTable)
        {
            Skip = skip;
            Take = take;
            ProductNameTable = productNameTable;
        }
    }       
}
