using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.Dotnet.Interfaces
{
    public interface IBaseAccount
    {
        bool IsActive { get; }

        string FirstName { get; }

        string LastName { get; }

        string FullName => FirstName + " " + LastName;
    }
}
