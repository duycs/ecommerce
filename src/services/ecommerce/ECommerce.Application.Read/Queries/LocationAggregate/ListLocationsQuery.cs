using ECommerce.Application.Models.Locations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Read.Queries.LocationAggregate
{
    public class ListLocationsQuery : IRequest<IEnumerable<ProvinceDto>>
    {
    }
}
