using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.SeedWork
{
    public interface IPriorityEntity
    {
        int Priority { get; }
    }

    public abstract class PriorityEntity : DateModiferTrackingEntity, IPriorityEntity
    {
        public int Priority { get; protected set; }
    }
}
