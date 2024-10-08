using Dapper;
using ECommerce.Application.Models.Brands;
using ECommerce.Application.Read.Queries.Brands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Read.QueryHandlers.Brands
{
    public class BrandsByCategoryIdHandler : IRequestHandler<BrandsByCategoryIdQuery, IEnumerable<BrandDto>>
    {
        private readonly IDbConnection _dbConnection;

        public BrandsByCategoryIdHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<BrandDto>> Handle(BrandsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var subCategoryIds = request.SubCategoryIds?.Where(a => a.HasValue).ToList() ?? new List<Guid?>();
            if (!request.ParentCategoryId.HasValue && !subCategoryIds.Any())
                return new List<BrandDto>();

            List<Guid> subCargoryIdsQuery = new List<Guid>();

            var builder = new SqlBuilder();           

            if (subCategoryIds.Any())
            {
                foreach (var item in subCategoryIds)
                {
                    subCargoryIdsQuery.Add(item.Value);
                }
            }
            else
            {
                if (request.ParentCategoryId.HasValue)
                {
                    var categoryTemplate = builder.AddTemplate(@"SELECT Id FROM product_categories WHERE parent_id = @ParentId");
                    var ids = await _dbConnection.QueryAsync<Guid>(categoryTemplate.RawSql,
                                new { ParentId = request.ParentCategoryId.Value });

                    if (ids.Any())
                        subCargoryIdsQuery.AddRange(ids);
                    else
                        return new List<BrandDto>();
                }
            }

            var brandsTemplate = builder.AddTemplate(@"select 
 	                                        b.id, b.name, b.image, b.priority 
                                        from brands b
                                        where 
                                            id = any(select brand_id from products where category_id = any(@SubCargoryIds))
                                        order by b.priority ");

            var resultBrand = await _dbConnection.QueryAsync<BrandDto>(brandsTemplate.RawSql,
                                                                       new { SubCargoryIds = subCargoryIdsQuery });
            return resultBrand;

        }
    }
}
