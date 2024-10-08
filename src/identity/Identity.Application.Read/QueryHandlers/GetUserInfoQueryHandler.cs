using Dapper;
using Identity.Application.Models;
using Identity.Application.Read.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Read.QueryHandlers
{
    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, AccountInfoDto>
    {
        private readonly IDbConnection _connection;

        public GetUserInfoQueryHandler(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<AccountInfoDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var template = new SqlBuilder().AddTemplate(@"select ""FirstName"", ""LastName"" from identity.""AspNetUsers"" where ""Id"" = @UserId limit 1");
            var result = await _connection.QueryFirstOrDefaultAsync<AccountInfoDto>(template.RawSql, request);
            return result;
        }
    }
}
