using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.SeedWork
{
    public class DateModiferTrackingEntityDto : ModifierTrackingDto
    {
        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset LastUpdatedDate { get; set; }
    }
    public abstract class ModifierTrackingDto : EntityDto
    {
        public string CreatedBy { get; set; }

        public Guid CreatedById { get; set; }

        public string LastUpdatedBy { get; set; }

        public Guid LastUpdatedById { get; set; }
    }
    public abstract class EntityDto
    {
        public Guid Id { get; set; }
    }
}
