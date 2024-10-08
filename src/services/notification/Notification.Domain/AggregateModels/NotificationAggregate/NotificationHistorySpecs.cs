using ECommerce.Shared.Dotnet.Specifications;
using System;

namespace Notification.Domain.AggregateModels.NotificationAggregate
{
    public static class NotificationHistorySpecs
    {
        public static ISpecification<NotificationHistory> ByUserId(Guid userId) => new Specification<NotificationHistory>(a => a.UserId == userId);
        public static ISpecification<NotificationHistory> ById(Guid id) => new Specification<NotificationHistory>(a => a.Id == id);
        public static ISpecification<NotificationHistory> ByIdAndUserId(Guid id, Guid userId) => ById(id).And(ByUserId(userId));
    }
}
