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
    public class GetAllProductsHandler:IQueryHandler<GetAllProductsQuery,List<ProductDTO>>
    {
        private readonly IProductRepository _repository;
        public GetAllProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ProductDTO>> Handle(GetAllProductsQuery request,CancellationToken cancellationToken)
        {
            var products = await _repository.GetWholeAsync(cancellationToken);
            return products.Adapt<List<Product>,List<ProductDTO>>();
        }
    }
}
