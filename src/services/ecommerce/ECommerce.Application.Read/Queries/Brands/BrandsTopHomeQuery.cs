﻿using ECommerce.Application.Models.Brands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Read.Queries.Brands
{
    public class BrandsTopHomeQuery : IRequest<IEnumerable<BrandsTopHomeDto>>
    {

    }
}
