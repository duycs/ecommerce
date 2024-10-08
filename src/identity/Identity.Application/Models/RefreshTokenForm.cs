using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Identity.Application.Models
{
    public class RefreshTokenForm
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
