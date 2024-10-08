using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SaasMigration.ECommerceModels.Models;
using SaasMigration.IntegrationModels;
using SaasMigration.IntegrationModels.Models;
using SaasMigration.Models;
using SaasMigration.SaasModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EComModels = SaasMigration.ECommerceModels.Models;
using SasModels = SaasMigration.SaasModels.Models;

namespace SaasMigration.Migrations
{
    public class ProductMigration : IMigrationTask
    {
        private readonly SaasDbContext _saasDbContext;
        private readonly EComDbContext _ecomDbContext;
        private readonly IntegrationDbContext _integrationDbContext;

        public ProductMigration(DbContextOptions<SaasDbContext> saasDbContext,
            DbContextOptions<EComDbContext> ecomDbContext,
            DbContextOptions<IntegrationDbContext> integrationDbContext)
        {
            _saasDbContext = new SaasDbContext(saasDbContext);
            _ecomDbContext = new EComDbContext(ecomDbContext);
            _integrationDbContext = new IntegrationDbContext(integrationDbContext);
        }

        public async Task RunAsync()
        {
            var wardId = await MigrateLocation();
            var brands = await MigrateBrands();
            var categories = await MigrateCategories();
            await MigrateProducts(brands, categories, wardId);
            await _ecomDbContext.SaveChangesAsync();

            MappingBrand(brands);
            MappingCategory(categories);
            await _integrationDbContext.SaveChangesAsync();
        }

        private async Task<Guid> MigrateLocation()
        {
            var result = new Guid();
            var provinces = await _saasDbContext.Provinces.ToListAsync();
            foreach (var province in provinces)
            {
                var newProvince = new EComModels.Province();
                newProvince.Id = Guid.NewGuid();
                newProvince.Name = province.Name;
                newProvince.Code = province.Code;
                newProvince.Type = province.Type;
                newProvince.CreatedDate = DateTime.UtcNow;
                newProvince.LastUpdatedDate = DateTime.UtcNow;
                newProvince.CreatedById = Guid.Empty;
                newProvince.LastUpdatedById = Guid.Empty;

                var districts = await _saasDbContext.Districts.Where(a => a.ProvinceId == province.Id).ToListAsync();
                foreach (var district in districts)
                {
                    var newDistrict = new EComModels.District();
                    newDistrict.Id = Guid.NewGuid();
                    newDistrict.Code = district.Code;
                    newDistrict.Name = district.Name;
                    newDistrict.Type = district.Type;
                    newDistrict.Location = district.Location;
                    newDistrict.CreatedDate = DateTime.UtcNow;
                    newDistrict.LastUpdatedDate = DateTime.UtcNow;
                    newDistrict.CreatedById = Guid.Empty;
                    newDistrict.LastUpdatedById = Guid.Empty;

                    var wards = await _saasDbContext.Wards.Where(a => a.DistrictId == district.Id).ToListAsync();
                    foreach (var ward in wards)
                    {
                        var newWard = new EComModels.Ward();
                        newWard.Id = Guid.NewGuid();
                        newWard.Code = ward.Code;
                        newWard.Name = ward.Name;
                        newWard.Type = ward.Type;
                        newWard.Location = ward.Location;
                        newWard.CreatedDate = DateTime.UtcNow;
                        newWard.LastUpdatedDate = DateTime.UtcNow;
                        newWard.CreatedById = Guid.Empty;
                        newWard.LastUpdatedById = Guid.Empty;

                        newDistrict.Wards ??= new List<EComModels.Ward>();
                        newDistrict.Wards.Add(newWard);
                        result = newWard.Id;
                    }

                    newProvince.Districts ??= new List<EComModels.District>();
                    newProvince.Districts.Add(newDistrict);
                }

                _ecomDbContext.Provinces.Add(newProvince);
            }

            return result;
        }

        private async Task<Dictionary<uint, Guid>> MigrateBrands()
        {
            var result = new Dictionary<uint, Guid>();
            var brands = await _saasDbContext.Brands.Where(b => b.IsDeleted == false).ToListAsync();
            foreach (var brand in brands)
            {
                var newBrand = new EComModels.Brand();
                newBrand.Id = Guid.NewGuid();
                newBrand.Code = brand.Code;
                newBrand.Name = brand.Name;
                newBrand.Slug = brand.Slug;
                newBrand.Description = brand.Description;
                newBrand.CreatedDate = DateTime.UtcNow;
                newBrand.LastUpdatedDate = DateTime.UtcNow;
                newBrand.CreatedById = Guid.Empty;
                newBrand.LastUpdatedById = Guid.Empty;

                _ecomDbContext.Brands.Add(newBrand);
                result.Add(brand.Id, newBrand.Id);
            }
            return result;
        }

        private async Task<Dictionary<Guid, IEnumerable<uint>>> MigrateCategories()
        {
            var categoriesFile = Path.Combine(Directory.GetCurrentDirectory(), "categories.json");
            var categoriesMapping = JsonConvert.DeserializeObject<IEnumerable<CategoryMappingSettings>>(await File.ReadAllTextAsync(categoriesFile));
            var result = new Dictionary<Guid, IEnumerable<uint>>();
            var mappingIds = categoriesMapping.Select(a => a.SaasId);

            foreach (var parent in categoriesMapping)
            {
                var cat = new EComModels.ProductCategory();
                cat.Id = Guid.NewGuid();
                cat.Name = parent.Name;
                cat.Code = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                cat.CreatedDate = DateTime.UtcNow;
                cat.LastUpdatedDate = DateTime.UtcNow;
                cat.CreatedById = Guid.Empty;
                cat.LastUpdatedById = Guid.Empty;
                cat.InverseParent = new List<EComModels.ProductCategory>();

                foreach (var child in parent.Children)
                {
                    var childCate = new EComModels.ProductCategory();
                    childCate.Id = Guid.NewGuid();
                    childCate.Name = child.Name;
                    childCate.Code = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                    childCate.CreatedDate = DateTime.UtcNow;
                    childCate.LastUpdatedDate = DateTime.UtcNow;
                    childCate.CreatedById = Guid.Empty;
                    childCate.LastUpdatedById = Guid.Empty;

                    cat.InverseParent.Add(childCate);
                    result.Add(childCate.Id, child.Children);
                }

                _ecomDbContext.ProductCategories.Add(cat);
            }

            return result;
        }

        private async Task MigrateProducts(Dictionary<uint, Guid> brands, Dictionary<Guid, IEnumerable<uint>> categories, Guid wardId)
        {
            var shop = new EComModels.Shop();
            shop.Id = Guid.NewGuid();
            shop.Name = "Saas";
            shop.Address = "";
            shop.Code = "Saas";
            shop.PhoneNumber = "";
            shop.WardId = wardId;
            shop.CreatedDate = DateTime.UtcNow;
            shop.LastUpdatedDate = DateTime.UtcNow;
            shop.CreatedById = Guid.Empty;
            shop.LastUpdatedById = Guid.Empty;
            shop.Products = new List<Product>();

            var productMapping = new Dictionary<Guid, uint>();

            var parentProducts = await _saasDbContext.Products.Where(a => a.IsDeleted == false && a.IsMigrationItem).ToListAsync();
            foreach (var product in parentProducts)
            {
                var category = categories.FirstOrDefault(a => a.Value.ToList().Contains((uint)product.CategoryId.Value)).Key;
                if (category == default) continue;
                var newProduct = new EComModels.Product();
                newProduct.Id = Guid.NewGuid();
                newProduct.Name = product.Name;
                newProduct.Description = product.Description;
                newProduct.Sku = product.Sku;
                newProduct.BrandId = product.BrandId == 0 ? null : brands[(uint)product.BrandId.Value];
                newProduct.CategoryId = category;
                newProduct.CreatedDate = DateTime.UtcNow;
                newProduct.LastUpdatedDate = DateTime.UtcNow;
                newProduct.CreatedById = Guid.Empty;
                newProduct.LastUpdatedById = Guid.Empty;
                if (!string.IsNullOrEmpty(product.Images))
                {
                    newProduct.Images = JsonConvert.DeserializeObject<ImageJsonData>(product.Images)?.Urls ?? Array.Empty<string>();
                }

                var mapping = new ProductMapping();
                mapping.ProductId = newProduct.Id;
                mapping.OldId = product.Id;
                _integrationDbContext.ProductMappings.Add(mapping);

                var children = await _saasDbContext.Products.Where(a => a.IsDeleted == false && a.ParentId == product.Id).ToListAsync();
                await MigrateProductChildren(children, newProduct);
                shop.Products.Add(newProduct);
            }

            _ecomDbContext.Shops.Add(shop);
        }

        private async Task MigrateProductChildren(IEnumerable<SasModels.Product> children, EComModels.Product parent)
        {
            var attributeIds = children.Select(a => a.AttributeFixedId).ToList()
                .Concat(children.Select(a => a.AttributeInputId))
                .Where(a => a != null)
                .Distinct()
                .Select(a => (uint)a)
                .ToList();

            var attributes = await _saasDbContext.ProductAttributes.Where(a => a.IsDeleted == false && attributeIds.Contains(a.Id)).ToListAsync();
            var attributeMapping = new Dictionary<uint, Guid>();
            foreach (var attribute in attributes.GroupBy(a => a.TypeCode, a => a, (a, b) => new { Key = a, Values = b }))
            {
                var newAtt = new EComModels.ProductAttribute();
                newAtt.Id = Guid.NewGuid();
                newAtt.Name = string.IsNullOrEmpty(attribute.Key) ? string.Empty : attribute.Key;
                newAtt.ProductId = parent.Id;
                newAtt.CreatedDate = DateTime.UtcNow;
                newAtt.LastUpdatedDate = DateTime.UtcNow;
                newAtt.CreatedById = Guid.Empty;
                newAtt.LastUpdatedById = Guid.Empty;
                newAtt.Priority = children.Any(a => attribute.Values.Any(b => b.Id == a.AttributeFixedId)) ? 1 : 2;

                foreach (var item in attribute.Values)
                {
                    var newAttValue = new EComModels.ProductAttributeValue();
                    newAttValue.Id = Guid.NewGuid();
                    newAttValue.Code = item.Code ?? string.Empty;
                    newAttValue.Value = item.Value ?? string.Empty;
                    newAttValue.Name = item.Label ?? string.Empty;
                    newAttValue.CreatedDate = DateTime.UtcNow;
                    newAttValue.LastUpdatedDate = DateTime.UtcNow;
                    newAttValue.CreatedById = Guid.Empty;
                    newAttValue.LastUpdatedById = Guid.Empty;

                    newAtt.ProductAttributeValues.Add(newAttValue);
                    attributeMapping.Add(item.Id, newAttValue.Id);

                    // Add mappings

                    var attrmapping = new AttributeMapping();
                    attrmapping.AttributeValueId = newAttValue.Id;
                    attrmapping.OldId = item.Id;
                    _integrationDbContext.AttributeMappings.Add(attrmapping);
                }

                _ecomDbContext.ProductAttributes.Add(newAtt);
            }

            foreach (var child in children)
            {
                var productChild = new EComModels.ProductChild();
                productChild.Id = Guid.NewGuid();
                productChild.Name = child.Name;
                productChild.Sku = child.Sku;
                productChild.CreatedDate = DateTime.UtcNow;
                productChild.LastUpdatedDate = DateTime.UtcNow;
                productChild.CreatedById = Guid.Empty;
                productChild.LastUpdatedById = Guid.Empty;
                productChild.ProductPrices ??= new List<EComModels.ProductPrice>();
                attributeMapping.TryGetValue((uint)child.AttributeFixedId, out var fixAtt);
                attributeMapping.TryGetValue((uint)child.AttributeInputId, out var inputAtt);
                var attributeValueIds = new Guid[] { };
                if (fixAtt != Guid.Empty)
                {
                    attributeValueIds = attributeValueIds.Append(fixAtt).ToArray();
                }
                if (inputAtt != Guid.Empty)
                {
                    attributeValueIds = attributeValueIds.Append(inputAtt).ToArray();
                }
                productChild.AttributeValueIds = attributeValueIds;

                var price = new EComModels.ProductPrice();
                price.Id = Guid.NewGuid();
                price.QuantityFrom = 0;
                price.ProductChildId = productChild.Id;
                price.ProductId = parent.Id;
                price.Price = child.PriceWholesale ?? 0;
                price.CreatedDate = DateTime.UtcNow;
                price.LastUpdatedDate = DateTime.UtcNow;
                price.CreatedById = Guid.Empty;
                price.LastUpdatedById = Guid.Empty;
                productChild.ProductPrices.Add(price);

                var stock = await _saasDbContext.ProductVendorStores.FirstOrDefaultAsync(a => a.IsDeleted == false && a.ProductId == child.Id);
                productChild.QuantityInStock = Convert.ToInt32(stock?.QuantityInstock ?? 0);

                parent.ProductChildren.Add(productChild);

                // Add mappings
                var mapping = new ChildProductMapping();
                mapping.ChildProductId = productChild.Id;
                mapping.OldId = child.Id;
                _integrationDbContext.ChildProductMappings.Add(mapping);
            }
        }

        private void MappingBrand(Dictionary<uint, Guid> brands)
        {
            foreach (var brand in brands)
            {
                var mapping = new BrandMapping();
                mapping.BrandId = brand.Value;
                mapping.OldId = brand.Key;
                _integrationDbContext.BrandMappings.Add(mapping);
            }
        }

        private void MappingCategory(Dictionary<Guid, IEnumerable<uint>> categories)
        {
            foreach (var categoryGroup in categories)
            {
                foreach (var category in categoryGroup.Value)
                {
                    var mapping = new CategoryMapping();
                    mapping.CategoryId = categoryGroup.Key;
                    mapping.OldId = category;
                    _integrationDbContext.CategoryMappings.Add(mapping);
                }
            }
        }
    }
}
