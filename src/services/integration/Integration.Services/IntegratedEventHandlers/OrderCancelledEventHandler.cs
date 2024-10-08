using Dapper;
using ECommerce.Shared.Configurations;
using ECommerce.Shared.Helpers;
using EventBus.Abstractions;
using Integration.Events.OrderEvents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Services.IntegratedEventHandlers
{
    public class OrderCancelledEventHandler : IIntegrationEventHandler<OrderCancelledIntegratedEvent>
    {
        private readonly IDbConnection _db;
        private readonly CustomHttpClient _httpClient;

        public OrderCancelledEventHandler(IDbConnection db, CustomHttpClient httpClient)
        {
            _db = db;
            _httpClient = httpClient;
        }

        public async Task Handle(OrderCancelledIntegratedEvent @event)
        {
            var mappingOrder = await _db.QueryFirstOrDefaultAsync<uint>(@"select old_id from integration.order_mappings where order_id = @OrderId limit 1", new
            {
                @event.OrderId
            });
            if (mappingOrder == 0)
            {
                return;
            }
            var response = await _httpClient.PutAsync(UrlsConfig.SaasMethods.CancelOrder(mappingOrder), new { });
            response.EnsureSuccessStatusCode();
            return;
        }
    }
}
