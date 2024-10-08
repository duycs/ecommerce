using Dapper;
using ECommerce.Shared.Configurations;
using ECommerce.Shared.Exceptions;
using ECommerce.Shared.Extensions;
using ECommerce.Shared.Helpers;
using EventBus.Abstractions;
using Integration.Application.QueryModels;
using Integration.Application.RequestModels;
using Integration.Application.ResponseModels;
using Integration.Domain.AggregateModels;
using Integration.Domain.AggregateModels.SystemLogAggregate;
using Integration.Domain.Enums;
using Integration.Domain.OrderAggregateModels;
using Integration.Events.OrderEvents;
using Integration.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Services.IntegratedEventHandlers
{
    public class OrderCreatedEventHandler : IIntegrationEventHandler<OrderCreatedIntegratedEvent>
    {
        private readonly IDbConnection _connection;
        private readonly IOrderMappingRepository _mappingRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IECommerceUnitOfWork _uow;
        private readonly CustomHttpClient _httpClient;
        private readonly ISystemLogRepository _systemLogRepository;
        private readonly ILogger<OrderCreatedEventHandler> _logger;

        public OrderCreatedEventHandler(IDbConnection connection,
            IOrderMappingRepository mappingRepository,
            IOrderRepository orderRepository,
            IECommerceUnitOfWork uow,
            CustomHttpClient httpClient,
            ISystemLogRepository systemLogRepository,
            ILogger<OrderCreatedEventHandler> logger)
        {
            _connection = connection;
            _mappingRepository = mappingRepository;
            _orderRepository = orderRepository;
            _uow = uow;
            _httpClient = httpClient;
            _systemLogRepository = systemLogRepository;
            _logger = logger;
        }

        public async Task Handle(OrderCreatedIntegratedEvent @event)
        {
            _logger.LogInformation("Start order created event with orderId = {OrderId}", @event.OrderId);
            SystemLog systemLog = new SystemLog("OrderCreatedEventHandler", StatusLog.Successed.Id);
            systemLog.AddContentLog("OrderCreatedIntegratedEvent", @event);

            var builder = new SqlBuilder();
            var template = builder.AddTemplate(@"select product_child_id, quantity from ""order"".order_details where order_id = @OrderId");
            var details = await _connection.QueryAsync<OrderDetailDto>(template.RawSql, new
            {
                OrderId = @event.OrderId,
            });
            var order = await _orderRepository.GetByIdAsync(@event.OrderId);

            var mappingResult = await _connection.QueryMultipleAsync(@"select old_id from integration.customer_mappings where customer_id = @CustomerId limit 1;
                select child_product_id as id, old_id from integration.child_product_mappings where child_product_id=any(@Ids)", new
            {
                CustomerId = order.CustomerId,
                Ids = details.Select(a => a.ProductChildId).ToArray()
            });
            var saasCustomerId = mappingResult.ReadFirst<uint>();
            var productMappings = mappingResult.Read<(Guid, uint)>();
            if (productMappings.IsNullOrEmpty())
            {
                return;
            }
            var request = new CreateOrderRequest()
            {
                CustomerId = saasCustomerId,
                Note = order.Note,
                ChildrenProducts = details.Select(d => new CreateOrderDetailtRequest()
                {
                    Id = productMappings.FirstOrDefault(m => m.Item1 == d.ProductChildId).Item2,
                    Quantity = Convert.ToUInt32(d.Quantity),
                })
            };
            var response = await _httpClient.PostAsync(UrlsConfig.SaasMethods.CreateOrder(), request);
            if(!response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Create Saas's Order failed with reason {0}", await response.Content.ReadAsStringAsync());
                systemLog.AddContentLog("Exception", response);
                systemLog.SetStatus(StatusLog.Failed.Id);
                _systemLogRepository.Add(systemLog);
            }
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsObjectAsync<CreateOrderResponse>();
            _logger.LogInformation("Create Saas's Order with Id = {Id}", data.Id);
            _mappingRepository.Add(new OrderMapping(@event.OrderId, data.Id));
            order.SaasCreated(data.OrderCode, data.CustomerOrderNumber);
            _orderRepository.Update(order);

            _systemLogRepository.Add(systemLog);
            await _uow.SaveChangesAsync();
        }
    }
}
