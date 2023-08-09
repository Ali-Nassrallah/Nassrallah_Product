using FluentValidation;
using Mapster;
using MediatR;
using NassrallahAPI.Application.DTOs;
using NassrallahAPI.Application.Repositories;
using NassrallahAPI.Domain.Entities;
using NassrallahAPI.Shared;
using NassrallahAPI.Shared.Abstractions.Application.Commands;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Application.Commands.OrderCommand.Handlers
{
    public class CreateOrderHandler:ICommandHandler<CreateOrderCommand,OrderDTO>
    {
        private readonly IOrderRepository  _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IValidator<Order> _validator;
        public CreateOrderHandler(IOrderRepository orderRepository,IProductRepository productRepository,IValidator<Order> validator)
        {
            _orderRepository = orderRepository;
            _productRepository=productRepository;
            _validator = validator;
        }
        public async Task<Response<OrderDTO>> Handle(CreateOrderCommand request,CancellationToken cancellationToken)
        {
            var (totalAmount, productIds)=request;
            var orderedProduct = new List<Product>();
            foreach(var Id in productIds)
            {
                orderedProduct.Add(await _productRepository.GetByIdAsync(Id,cancellationToken));
            }
            var order=new Order(totalAmount,orderedProduct);
            var valid = await _validator.ValidateAsync(order);
            if (!valid.IsValid)
                throw new ValidationException(valid.Errors);
            var newOrder = await _orderRepository.AddAsync(order, cancellationToken);
            return Response.Success(newOrder.Adapt<Order, OrderDTO>(), "Order created successfully");
        }
    }
}
