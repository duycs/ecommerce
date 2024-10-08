using ECommerce.Shared.Extensions;
using Order.Application.ResponseModels;
using System;

namespace Order.Application.Models.Orders
{
    public class LiabilityDto : LiabilityResponse
    {
        public DateTime LiabilityTime => DateTimExtention.UnixToTime(CreatedTime);
    }
}
