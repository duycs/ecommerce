using ECommerce.Application.Models.Brands;
using MediatR;
using System;
using System.Collections.Generic;

namespace ECommerce.Application.Read.Queries.Brands
{
    public class BrandsByCategoryIdQuery : IRequest<IEnumerable<BrandDto>>
    {
        public Guid? ParentCategoryId { get; private set; }
        public IList<Guid?> SubCategoryIds { get; private set; }

        public BrandsByCategoryIdQuery(Guid? parentCategoryId, IList<Guid?> subCategoryIds)
        {
            ParentCategoryId = parentCategoryId;
            SubCategoryIds = subCategoryIds;
        }
    }
}
