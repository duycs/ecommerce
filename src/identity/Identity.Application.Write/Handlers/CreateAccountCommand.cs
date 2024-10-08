using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Identity.Application.Write.Handlers
{
    public class CreateAccountCommand : IRequest
    {
        [Required]
        [RegularExpression(@"^((\+)84|0)[1-9](\d{2}){4}$", ErrorMessage = "Phone number is invalid")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^.{6,}$", ErrorMessage = "Passwords must be at least 6 characters")]
        public string Password { get; set; }

        public Guid? WardId { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
