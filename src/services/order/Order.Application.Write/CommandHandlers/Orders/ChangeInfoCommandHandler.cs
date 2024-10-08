using ECommerce.Shared.Exceptions;
using MediatR;
using Order.Application.Write.Commands.Orders;
using Order.Domain.AggregateModels.OrderAggregate;
using Order.Infrastructure;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using EventBus.Abstractions;
using Integration.Events.OrderEvents;
using ECommerce.Shared.Extensions;

namespace Order.Application.Write.CommandHandlers.Orders
{
    public class ChangeInfoCommandHandler : IRequestHandler<ChangeInfoCommand>
    {
        private readonly IDbConnection _dbConnection;
        private readonly ICustomerOrderRepository _orderRepository;
        private readonly IOrderUnitOfWork _uow;
        private readonly IEventBus _eventBus;

        public ChangeInfoCommandHandler(IDbConnection dbConnection, ICustomerOrderRepository orderRepository, IOrderUnitOfWork uow, IEventBus eventBus)
        {
            _dbConnection = dbConnection;
            _orderRepository = orderRepository;
            _uow = uow;
            _eventBus = eventBus;
        }

        public async Task<Unit> Handle(ChangeInfoCommand request, CancellationToken cancellationToken)
        {
            //var order = await _orderRepository.GetSingleAsync(OrderSpecs.GetByIdAndCustomerId(request.Id, request.CustomerId));
            var order = await _orderRepository.GetByIdAsync(request.Id);

            if (order == null)
                throw new BusinessRuleException(ECommerceBusinessRule.NoOrderFound);

            var builder = new SqlBuilder();
            var template = builder.AddTemplate(@"select 
                                        address.*,
                                        ward.name as ward_name , 
                                        district.id as district_id,  district.name as district_name,
                                        province.id as province_id, province.name as province_name
                                        from
	                                        (select 
 	                                        address, receiver_name, receiver_phone_number, ward_id 
	                                        FROM public.customer_addresses where id = @Id) address
                                        inner join public.wards as  ward on  ward.id = address.ward_id
                                        inner join public.districts as district on ward.district_id = district.id
                                        inner join public.provinces as province on district.province_id = province.id
                                        limit 1;");

            var addressReceicer = await _dbConnection.QueryFirstOrDefaultAsync<AddressReceicerDto>(template.RawSql, new { Id = request.AddressId });

            if (addressReceicer == null)
                throw new BusinessRuleException(ECommerceBusinessRule.AddressNotFound);


            order.ChangeInfo(
                customerName: addressReceicer.ReceiverName,
                customerPhone: addressReceicer.ReceiverPhoneNumber,
                customerAddress: addressReceicer.Address,
                provinceId: addressReceicer.ProvinceId,
                provinceName: addressReceicer.ProvinceName,
                districtId: addressReceicer.DistrictId,
                districtName: addressReceicer.DistrictName,
                wardId: addressReceicer.WardId,
                wardName: addressReceicer.WardName,
                note: request.Note
                );

            _orderRepository.Update(order);

            await _uow.SaveChangesAsync();
            _eventBus.Publish(new OrderNoteUpdatedIntegratedEvent()
            {
                OrderId = order.Id,
                Note = order.Note,
            });

            return Unit.Value;
        }

        private class AddressReceicerDto
        {
            public string Address { get; set; }
            public string ReceiverName { get; set; }
            public string ReceiverPhoneNumber { get; set; }
            public Guid WardId { get; set; }
            public string WardName { get; set; }
            public Guid DistrictId { get; set; }
            public string DistrictName { get; set; }
            public Guid ProvinceId { get; set; }
            public string ProvinceName { get; set; }


        }
    }
}
