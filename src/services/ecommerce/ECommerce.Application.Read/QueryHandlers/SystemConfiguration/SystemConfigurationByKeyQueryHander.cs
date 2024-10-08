using Dapper;
using ECommerce.Application.Models.SystemConfiguration;
using ECommerce.Application.Read.Queries.SystemConfiguration;
using MediatR;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Read.QueryHandlers.SystemConfiguration
{
    public class SystemConfigurationByKeyQueryHander : IRequestHandler<SystemConfigurationByKeyQuery, SytemConfigDto>
    {
        private readonly IDbConnection _dbConnection;

        public SystemConfigurationByKeyQueryHander(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<SytemConfigDto> Handle(SystemConfigurationByKeyQuery request, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();
            var template = builder.AddTemplate(@"SELECT key, value, name, description from system_configurations where key = @Key limit 1");
            var result = await _dbConnection.QueryFirstOrDefaultAsync<SytemConfigDto>($@"{template.RawSql}", request);
            return result;
        }
    }
}
