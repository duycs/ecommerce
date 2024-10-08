using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Identity.Application.Models
{
    public class LoginForm
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^.{6,}$", ErrorMessage = "Passwords must be at least 6 characters")]
        public string Password { get; set; }
    }
}
