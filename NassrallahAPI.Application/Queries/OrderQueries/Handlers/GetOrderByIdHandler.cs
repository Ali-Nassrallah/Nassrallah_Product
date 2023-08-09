using Mapster;
using MediatR;
using NassrallahAPI.Application.DTOs;
using NassrallahAPI.Application.Repositories;
using NassrallahAPI.Domain.Entities;
using NassrallahAPI.Shared.Abstractions.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Application.Queries.OrderQueries.Handlers
{
    public class GetOrderByIdHandler:IQueryHandler<GetOrderByIdQuery,OrderDTO>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrderByIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderDTO> Handle(GetOrderByIdQuery request,CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetWholeByIdAsync(request.Id, cancellationToken);
            return order.Adapt<Order, OrderDTO>();
        }
    }
}
