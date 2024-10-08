using Dapper;
using ECommerce.Application.Models.Locations;
using ECommerce.Application.Read.Queries.LocationAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Read.QueryHandlers.LocationAggregate
{
    public class ListLocationsQueryHandler : IRequestHandler<ListLocationsQuery, IEnumerable<ProvinceDto>>
    {
        private readonly IDbConnection _dbConnection;

        public ListLocationsQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<ProvinceDto>> Handle(ListLocationsQuery request, CancellationToken cancellationToken)
        {
            var template = new SqlBuilder().AddTemplate(@"select p.id, p.code, p.name, p.type, d.id, d.code, d.name, d.type, w.id, w.code, w.name, w.type
                            from provinces p
                            join districts d on p.id = d.province_id
                            join wards w on d.id = w.district_id");
            var provincesDict = new Dictionary<Guid, ProvinceDto>();
            var districtsDict = new Dictionary<Guid, Dictionary<Guid, DistrictDto>>();
            await _dbConnection.QueryAsync<ProvinceDto, DistrictDto, BaseLocationDto, BaseLocationDto>(template.RawSql,
                (province, district, ward) =>
            {
                provincesDict.TryGetValue(province.Id, out var provinceDto);
                if (provinceDto == null)
                {
                    provincesDict.Add(province.Id, province);
                }
                districtsDict.TryGetValue(province.Id, out var wardsDict);
                if (wardsDict == null)
                {
                    district.Wards = new List<BaseLocationDto>() { ward };
                    districtsDict.Add(province.Id, new Dictionary<Guid, DistrictDto>()
                    {
                        {district.Id, district},
                    });
                }
                else
                {
                    wardsDict.TryGetValue(district.Id, out var districtDto);
                    if (districtDto == null)
                    {
                        district.Wards = new List<BaseLocationDto>() { ward };
                        wardsDict.Add(district.Id, district);
                    }
                    else
                    {
                        districtDto.Wards.Add(ward);
                    }
                }
                return ward;
            });
            var result = provincesDict.Values.Select(p =>
            {
                p.Districts = districtsDict[p.Id].Values.Select(a => a);
                return p;
            });
            return result;
        }
    }
}
