using ECommerce.Application.Models.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Read.Queries.Products
{
    public class ProductDetailsQuery : IRequest<ProductDetailsDto>
    {
        public Guid CustomerId { get; private set; }
        public Guid ProductId { get; private set; }

        public ProductDetailsQuery(Guid customerId, Guid productId)
        {
            CustomerId = customerId;
            ProductId = productId;
        }
    }
}
