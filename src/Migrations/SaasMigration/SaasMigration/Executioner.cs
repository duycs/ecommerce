using SaasMigration.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasMigration
{
    public class Executioner
    {
        private readonly ProductMigration _productMigration;
        private readonly CustomerMigration _customerMigration;

        public Executioner(ProductMigration productMigration, CustomerMigration customerMigration)
        {
            _productMigration = productMigration;
            _customerMigration = customerMigration;
        }

        public async Task MigrateAllAsync()
        {
            await _productMigration.RunAsync();
            await _customerMigration.RunAsync();
        }
    }
}
