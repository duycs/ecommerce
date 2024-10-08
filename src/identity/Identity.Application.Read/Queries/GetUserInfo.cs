using Identity.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Read.Queries
{
    public class GetUserInfoQuery : IRequest<AccountInfoDto>
    {
        public Guid UserId { get; private set; }

        public GetUserInfoQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
