using ECommerce.Application.Models.Products;
using ECommerce.Shared.Dotnet.Repositories;
using ECommerce.Shared.Extensions;
using MediatR;
using System;
using System.Collections.Generic;

namespace ECommerce.Application.Read.Queries.Products
{
    public class SearchListProductsQuery : IRequest<QueryResult<SearchProductDto>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public IList<Guid?> SubCategoryIds { get; set; }
        public IList<Guid?> BrandIds { get; set; }
        public string SearchValue { get; set; }
        public string SearchQuery => string.IsNullOrEmpty(SearchValue) ? null : $@"%{SearchValue.NonUnicode()}%";
        public int ProductTypeId { get; set; } 
        public Guid? ParentCategoryId { get; set; }
        public uint QuantityStatus { get; set; }
    }
}
