using MediatR;
using NassrallahAPI.Application.Repositories;
using NassrallahAPI.Shared;
using NassrallahAPI.Shared.Abstractions.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Application.Commands.OrderCommand.Handlers
{
    public class DeleteOrderHandler :ICommandHandler<DeleteOrderCommand,Unit>
    {
        private readonly IOrderRepository _orderRepository;
        public DeleteOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Response<Unit>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderRepository.GetByIdAsync(request.Id, cancellationToken);
            return Response.Success(Unit.Value, "Deleted Order");
        }
    }
}
