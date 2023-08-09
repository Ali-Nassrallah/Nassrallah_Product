using Microsoft.AspNetCore.Mvc;
using MediatR;
using NassrallahAPI.Application.DTOs;
using NassrallahAPI.Application.Queries.ProductQueries;
using NassrallahAPI.Application.Commands.ProductCommand;
using NassrallahAPI.Shared;

namespace Nassrallah_Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAllProducts")]
        public async Task<List<ProductDTO>> Get(GetAllProductsQuery query, CancellationToken cancellationToken) 
            
            => await _mediator.Send(query, cancellationToken);

        [HttpGet("GetProductById")]
        public async Task<ProductDTO> Get(GetProductByIdQuery query, CancellationToken cancellationToken) 
            => await _mediator.Send(query, cancellationToken);

        [HttpPost("PostProduct")]
        public async Task<Response<ProductDTO>> Post(CreateProductCommand command, CancellationToken cancellationToken) 
            => await _mediator.Send(command, cancellationToken);
        
        [HttpPut("UpdateProduct")]
        public async Task<Response<ProductDTO>> Put(UpdateProductCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpDelete("DeleteProduct")]
        public async Task<Response<Unit>> Delete(DeleteProductCommand command, CancellationToken cancellationToken) 
            => await _mediator.Send(command, cancellationToken);
    }
}
