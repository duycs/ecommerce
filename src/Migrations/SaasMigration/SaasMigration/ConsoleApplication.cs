using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SaasMigration.SaasModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasMigration
{
    public class ConsoleApplication
    {
        private readonly ILogger _logger;
        private readonly Executioner _executioner;

        public ConsoleApplication(ILoggerFactory loggerFactory,
            Executioner executioner)
        {
            _logger = loggerFactory.CreateLogger<ConsoleApplication>();
            _executioner = executioner;
        }

        public async Task RunAsync()
        {
            await _executioner.MigrateAllAsync();
        }
    }
}
