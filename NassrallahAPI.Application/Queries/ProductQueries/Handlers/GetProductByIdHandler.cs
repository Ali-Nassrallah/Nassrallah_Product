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

namespace NassrallahAPI.Application.Queries.ProductQueries.Handlers
{
    public class GetProductByIdHandler:IQueryHandler<GetProductByIdQuery,ProductDTO>
    {
        private readonly IProductRepository _repository;
        public GetProductByIdHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProductDTO> Handle(GetProductByIdQuery request,CancellationToken cancellationToken)
        {
            var product = await _repository.GetWholeByIdAsync(request.Id, cancellationToken);
            return product.Adapt<Product, ProductDTO>();
        }
    }
}
