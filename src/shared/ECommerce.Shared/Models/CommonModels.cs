using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.Models
{
    internal class CommonModels
    {
    }

    public class Item
    {
        public Guid Id { get; set; }
        public uint Quantity { get; set; }
    }
}
