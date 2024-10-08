using ECommerce.Application.Models.ProductCategories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Read.Queries.ProductCategories
{
    public class ProductCategoriesQuery : IRequest<IEnumerable<ProductCategoryDto>>
    {
        public ProductCategoriesQuery() { }
    }
}
