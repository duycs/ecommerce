using AutoMapper;
using ECommerce.Domain.AggregateModels.CartAggregate;
using ECommerce.Domain.AggregateModels.CustomerAggregate;
using ECommerce.Domain.AggregateModels.ProductAttributeAggregate;
using ECommerce.Shared.Extensions;
using Integration.Events.CustomerEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerAddress, CustomerOrderedIntegratedEvent>()
                .ForMember(a => a.CustomerId, b => b.MapFrom(c => c.CustomerId))
                .ForMember(a => a.CustomerName, b => b.MapFrom(c => c.ReceiverName))
                .ForMember(a => a.CustomerPhone, b => b.MapFrom(c => c.ReceiverPhoneNumber))
                .ForMember(a => a.CustomerAddress, b => b.MapFrom(c => c.Address))
                .ForMember(a => a.WardId, b => b.MapFrom(c => c.WardId))
                .ForMember(a => a.WardName, b => b.MapFrom(c => c.Ward != null ? c.Ward.Name : string.Empty))
                .ForMember(a => a.DistrictId, b => b.MapFrom(c => c.WardId != null ? c.Ward.DistrictId : (Guid?)null))
                .ForMember(a => a.DistrictName, b => b.MapFrom(c => c.WardId != null ? c.Ward.District.Name : string.Empty))
                .ForMember(a => a.ProvinceId, b => b.MapFrom(c => c.WardId != null ? c.Ward.District.ProvinceId : (Guid?)null))
                .ForMember(a => a.ProvinceName, b => b.MapFrom(c => c.WardId != null ? c.Ward.District.Province.Name : string.Empty));

            CreateMap<ProductAttributeValue, OrderCreatedProductAttributeValue>()
                .ForMember(a => a.AttributeName, b => b.MapFrom(c => c.ProductAttribute.Name))
                .ForMember(a => a.Priority, b => b.MapFrom(c => c.ProductAttribute.Priority));

            CreateMap<CartDetail, OrderCreatedDetailIntegratedEvent>()
                .ForMember(a => a.ProductId, b => b.MapFrom(c => c.ProductChild.ProductId))
                .ForMember(a => a.ProductSku, b => b.MapFrom(c => c.ProductChild.Product.Sku))
                .ForMember(a => a.ProductName, b => b.MapFrom(c => c.ProductChild.Product.Name))
                .ForMember(a => a.ProductImage, b => b.MapFrom(c => c.ProductChild.Product.Image != null ? c.ProductChild.Product.Image : String.Empty))
                .ForMember(a => a.ProductChildName, b => b.MapFrom(c => c.ProductChild.Name))
                .ForMember(a => a.ProductChildSku, b => b.MapFrom(c => c.ProductChild.Sku))
                .ForMember(a => a.BrandId, b => b.MapFrom(c => c.ProductChild.Product.BrandId))
                .ForMember(a => a.BrandName, b => b.MapFrom(c => c.ProductChild.Product.BrandId != null ? c.ProductChild.Product.Brand.Name : String.Empty))
                .ForMember(a => a.ProductCategoryId, b => b.MapFrom(c => c.ProductChild.Product.CategoryId))
                .ForMember(a => a.ProductCategoryName, b => b.MapFrom(c => c.ProductChild.Product.Category.Name))
                .ForMember(a => a.ShopId, b => b.MapFrom(c => c.ProductChild.Product.ShopId))
                .ForMember(a => a.ShopName, b => b.MapFrom(c => c.ProductChild.Product.ShopId != null ? c.ProductChild.Product.Shop.Name : String.Empty))
                .ForMember(a => a.AttributeValues, b => b.MapFrom(c => c.ProductChild.Product.Attributes.SelectMany(a => a.ProductAttributeValues).Where(a => c.ProductChild.AttributeValueIds.Contains(a.Id)).To<IEnumerable<OrderCreatedProductAttributeValue>>()));

            CreateMap<Cart, CustomerOrderedIntegratedEvent>()
                .ForMember(a => a.Note, b => b.MapFrom(c => c.Note))
                .ForMember(a => a.DateTimeOrder, b => b.MapFrom(c => DateTime.UtcNow))
                .ForMember(a => a.Details, b => b.MapFrom(c => c.CartDetails.To<IEnumerable<OrderCreatedDetailIntegratedEvent>>()));
        }
    }
}
