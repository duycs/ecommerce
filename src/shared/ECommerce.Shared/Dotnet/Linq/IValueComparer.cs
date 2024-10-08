using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.Dotnet.Linq
{
    internal interface IValueComparer<in T>
    {
        bool Compare(T x, T y);
    }
}
