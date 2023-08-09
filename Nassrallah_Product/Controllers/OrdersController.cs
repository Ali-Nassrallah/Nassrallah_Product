using Microsoft.AspNetCore.Mvc;
using MediatR;
using NassrallahAPI.Application.DTOs;
using NassrallahAPI.Application.Queries.OrderQueries;
using NassrallahAPI.Application.Commands.ProductCommand;
using NassrallahAPI.Application.Queries.ProductQueries;
using NassrallahAPI.Application.Commands.OrderCommand;
using NassrallahAPI.Shared;

namespace Nassrallah_Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
           => _mediator = mediator;

        [HttpGet("GetAllOrders")]
        public async Task<List<OrderDTO>> Get(GetAllOrdersQuery query, CancellationToken cancellationToken) 
            => await _mediator.Send(query, cancellationToken);

        [HttpGet("GetOrderById")]
        public async Task<OrderDTO> Get(GetOrderByIdQuery query, CancellationToken cancellationToken) 
            => await _mediator.Send(query, cancellationToken);

        [HttpPost("PosOrder")]
        public async Task<Response<OrderDTO>> Post(CreateOrderCommand command, CancellationToken cancellationToken) 
            => await _mediator.Send(command, cancellationToken);

        [HttpPut("UpdateOrder")]
        public async Task<Response<OrderDTO>> Put(UpdateOrderCommand command, CancellationToken cancellationToken) 
            => await _mediator.Send(command, cancellationToken);

        [HttpDelete("DeleteOrder")]
        public async Task<Response<Unit>> Delete(DeleteOrderCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

    }
}
