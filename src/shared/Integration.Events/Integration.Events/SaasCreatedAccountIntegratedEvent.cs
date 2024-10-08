using EventBus.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Integration.Events
{
    public class SaasCreatedAccountIntegratedEvent : IntegrationEvent
    {
        [Required]
        public Guid AccountId { get; set; }

        [Required]
        [RegularExpression(@"^((\+)84|0)[1-9](\d{2}){4}$", ErrorMessage = "Phone number is invalid")]
        public string UserName { get; set; }

        public Guid? WardId { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
