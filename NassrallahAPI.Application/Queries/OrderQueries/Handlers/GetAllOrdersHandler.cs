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
    public class GetAllOrdersHandler : IQueryHandler<GetAllOrdersQuery,List<OrderDTO>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetAllOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<OrderDTO>> Handle(GetAllOrdersQuery request,CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetWholeAsync(cancellationToken);
            return orders.Adapt<List<Order>,List<OrderDTO>>();
        }
    }
}
