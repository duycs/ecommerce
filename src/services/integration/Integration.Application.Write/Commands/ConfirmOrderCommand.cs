using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Integration.Application.Write.Commands
{
    public class ConfirmOrderCommand : IRequest
    {
        public uint OrderId { get; set; }
        public string StaffName { get; set; }
        [RegularExpression(@"^[0-9]{9,11}$", ErrorMessage = "Staff phone number is invalid")]
        public string StaffPhone { get; set; }
    }
}
