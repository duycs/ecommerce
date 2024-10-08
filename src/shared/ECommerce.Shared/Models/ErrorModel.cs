using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.Models
{
    public class ErrorModel
    {
        public string Error { get; set; }
        public string Description { get; set; }

        public ErrorModel(string error, string description)
        {
            Error = error;
            Description = description;
        }
    }
}
