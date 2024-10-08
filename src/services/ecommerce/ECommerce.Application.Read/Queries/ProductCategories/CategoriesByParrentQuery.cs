using ECommerce.Application.Models.ProductCategories;
using MediatR;
using System;
using System.Collections.Generic;

namespace ECommerce.Application.Read.Queries.ProductCategories
{
    public class CategoriesByParrentQuery : IRequest<IEnumerable<ProductCategoryDto>>
    {
        public Guid ParentId { get; private set; }
        public CategoriesByParrentQuery(Guid parentId)
        {
            ParentId = parentId;
        }
    }
}
