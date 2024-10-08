using Dapper;
using ECommerce.Application.Models.Customers;
using ECommerce.Application.Read.Queries.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ECommerce.Application.Read.QueryHandlers.Customers
{
    public class CustomerAddressListQueryHandler : IRequestHandler<CustomerAddressListQuery, IEnumerable<CustomerAddressDto>>
    {
        private IDbConnection _dbConnection;

        public CustomerAddressListQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<CustomerAddressDto>> Handle(CustomerAddressListQuery request, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();

            var itemsTemplate = builder.AddTemplate(@"
                                            SELECT cus_address.*, wards.id as ward_id, wards.name as ward_name,
                                                   districts.id as district_id, districts.name as district_name, provinces.id as province_id, provinces.name as province_Name
                                            FROM
                                                (SELECT id, address, is_default, receiver_name, receiver_phone_number, ward_id FROM customer_addresses WHERE customer_id = @CustomerId) cus_address
                                            LEFT JOIN wards ON cus_address.ward_id = wards.id
                                            LEFT JOIN districts ON  wards.district_id = districts.id
                                            LEFT JOIN provinces ON districts.province_id = provinces.id");

            IEnumerable<CustomerAddressDto> items = await _dbConnection.QueryAsync<CustomerAddressDto>(itemsTemplate.RawSql, request);

            return items;
        }
    }
}
