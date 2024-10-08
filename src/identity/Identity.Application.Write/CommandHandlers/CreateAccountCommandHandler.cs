using ECommerce.Shared.Exceptions;
using EventBus.Abstractions;
using Identity.Application.Write.Handlers;
using Identity.Domain.AccountAggregate;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Data;
using Dapper;
using System.Threading;
using System.Threading.Tasks;
using Integration.Events.CustomerEvents;
using ECommerce.Shared.Extensions;

namespace Identity.Application.Write.CommandHandlers
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand>
    {
        private readonly UserManager<Account> _userManager;
        private readonly IEventBus _eventBus;
        private readonly IDbConnection _connection;

        public CreateAccountCommandHandler(UserManager<Account> userManager, IEventBus eventBus, IDbConnection connection)
        {
            _userManager = userManager;
            _eventBus = eventBus;
            _connection = connection;
        }

        public async Task<Unit> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            if (await _userManager.FindByNameAsync(request.UserName) != null)
            {
                throw new BusinessRuleException(ECommerceBusinessRule.UserNameExists);
            }
            var passwordValidator = new PasswordValidator<Account>();
            if (!(await passwordValidator.ValidateAsync(_userManager, null, request.Password)).Succeeded)
            {
                throw new BusinessRuleException(ECommerceBusinessRule.PasswordInvalid);
            }
            if (request.WardId.HasValue)
            {
                var exists = await _connection.ExecuteScalarAsync<bool>(@"select count(1) from public.wards where id = @WardId", new
                {
                    WardId = request.WardId.Value,
                });
                if (!exists)
                {
                    throw new BusinessRuleException(ECommerceBusinessRule.WardNotExists);
                }
            }
            var account = new Account(request.UserName, true, request.FirstName, request.LastName);
            await _userManager.CreateAsync(account, request.Password);
            var integratedEvent = new AccountCreatedIntegratedEvent()
            {
                WardId = request.WardId,
                Address = request.Address,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.UserName,
                UserId = account.Id
            };
            _eventBus.Publish(integratedEvent);
            return Unit.Value;
        }
    }
}
