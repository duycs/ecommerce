using ECommerce.Application.Models.SystemConfiguration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Read.Queries.SystemConfiguration
{
    public class SystemConfigurationByKeyQuery : IRequest<SytemConfigDto>
    {
        public string Key { get; private set; }

        public SystemConfigurationByKeyQuery(string key)
        {
            Key = key;
        }
    }
}
