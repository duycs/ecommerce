using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.Mvc
{
    public interface IScopeContext
    {
        Guid CurrentAccountId { get; }

        string CurrentAccountName { get; }

        string CurrentAccountEmail { get; }

        List<string> AcceptLanguages { get; }
    }
}
