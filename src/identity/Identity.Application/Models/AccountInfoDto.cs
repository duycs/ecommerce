using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Models
{
    public class AccountInfoDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
