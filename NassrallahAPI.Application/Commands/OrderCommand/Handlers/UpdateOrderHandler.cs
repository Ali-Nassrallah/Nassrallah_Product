using FluentValidation;
using Mapster;
using MediatR;
using NassrallahAPI.Application.DTOs;
using NassrallahAPI.Application.Repositories;
using NassrallahAPI.Domain.Entities;
using NassrallahAPI.Shared;
using NassrallahAPI.Shared.Abstractions.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Application.Commands.OrderCommand.Handlers
{
    public class UpdateOrderHandler :ICommandHandler<UpdateOrderCommand, OrderDTO>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IValidator<Order> _validator;
        public UpdateOrderHandler(IOrderRepository orderRepository, IValidator<Order> validator)
        {
            _orderRepository = orderRepository;
            _validator = validator;
        }
        public async Task<Response<OrderDTO>> Handle(UpdateOrderCommand request,CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);
            var valid = await _validator.ValidateAsync(order);

            if (!valid.IsValid)
                throw new ValidationException(valid.Errors);
            order.Update(request.TotalAmount);
            await _orderRepository.UpdateAsync(order, cancellationToken);
            return Response.Success(order.Adapt<Order, OrderDTO>(), "Product updated successfully");
        }
    }
}
