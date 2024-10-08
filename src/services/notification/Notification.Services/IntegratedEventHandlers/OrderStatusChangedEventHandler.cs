using ECommerce.Shared.Enum;
using ECommerce.Shared.Helpers;
using EventBus.Abstractions;
using Integration.Events.OrderEvents;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Notification.Domain.AggregateModels.NotificationAggregate;
using Notification.Domain.AggregateModels.TemplateAggregate;
using Notification.Infrastructure;
using Notification.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Services.IntegratedEventHandlers
{
    public class OrderStatusChangedEventHandler : IIntegrationEventHandler<OrderStatusChangedIntegratedEvent>
    {
        private readonly INotificationService _notificationService;
        private readonly ILogger<OrderStatusChangedEventHandler> _logger;
        private readonly INotificationHistoryRepository _historyRepo;
        private readonly INotificationTemplateRepository _templateRepo;
        private readonly INotificationUnitOfWork _uow;

        public OrderStatusChangedEventHandler(INotificationService notificationService,
            ILogger<OrderStatusChangedEventHandler> logger,
            INotificationHistoryRepository historyRepo,
            INotificationTemplateRepository templateRepo,
            INotificationUnitOfWork uow)
        {
            _notificationService = notificationService;
            _logger = logger;
            _historyRepo = historyRepo;
            _templateRepo = templateRepo;
            _uow = uow;
        }

        public async Task Handle(OrderStatusChangedIntegratedEvent @event)
        {
            NotificationHistory history = null;
            var timeZoneId = TimeZoneInfo.FindSystemTimeZoneById("Asia/Bangkok");
            var data = new
            {
                OrderId = @event.OrderId,
                SaasCode = @event.SaasCode,
                Date = TimeZoneInfo.ConvertTimeFromUtc(@event.CreationDate, timeZoneId).ToString("dd/MM/yyyy HH:mm")
            };

            if (@event.CurrentStatus == OrderStatus.Executing.Id)
            {
                history = new NotificationHistory(@event.UserId, await _templateRepo.GetByKeyAsync(NotificationTemplateKey.OrderConfirmed), data);
            }
            else if (@event.CurrentStatus == OrderStatus.Shipping.Id)
            {
                history = new NotificationHistory(@event.UserId, await _templateRepo.GetByKeyAsync(NotificationTemplateKey.OrderShipping), data);
            }
            else if (@event.CurrentStatus == OrderStatus.Completed.Id)
            {
                history = new NotificationHistory(@event.UserId, await _templateRepo.GetByKeyAsync(NotificationTemplateKey.OrderShipped), data);
            }
            else if (@event.CurrentStatus == OrderStatus.Cancel.Id)
            {
                history = new NotificationHistory(@event.UserId, await _templateRepo.GetByKeyAsync(NotificationTemplateKey.OrderCanceled), data);
            }
            else
            {
                _logger.LogError("No template match with status");
                throw new Exception();
            }

            if (await _notificationService.Notify(history.UserId, history.Title, history.Content))
            {
                _historyRepo.Add(history);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
