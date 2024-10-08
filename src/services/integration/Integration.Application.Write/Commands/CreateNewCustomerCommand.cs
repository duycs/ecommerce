using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Integration.Application.Write.Commands
{
    public class CreateNewCustomerCommand : IRequest
    {
        [Required]
        public uint CustomerId { get; set; }

        [Required]
        [RegularExpression(@"^((\+)84|0)[1-9](\d{2}){4}$", ErrorMessage = "Phone number is invalid")]
        public string UserName { get; set; }

        public string WardCode { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
