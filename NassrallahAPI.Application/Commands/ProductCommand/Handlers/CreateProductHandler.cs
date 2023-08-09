using NassrallahAPI.Application.DTOs;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using NassrallahAPI.Application.Repositories;
using NassrallahAPI.Domain.Entities;
using NassrallahAPI.Shared.Abstractions.Application.Commands;
using NassrallahAPI.Shared;
using FluentValidation;

namespace NassrallahAPI.Application.Commands.ProductCommand.Handlers
{
    public class CreateProductHandler : ICommandHandler<CreateProductCommand, ProductDTO>
    {
        private readonly IProductRepository _repository;
        private readonly IValidator<Product> _validator;
        public CreateProductHandler(IProductRepository repository,IValidator<Product> validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task<Response<ProductDTO>> Handle(CreateProductCommand request,CancellationToken cancellationToken)
        {
            var (Name, Description, Price, Quantity) = request;
            var product=new Product(Name, Description, Price, Quantity);
            var valid = await _validator.ValidateAsync(product);
            if (!valid.IsValid) 
                throw new ValidationException(valid.Errors);
            var newProduct=await _repository.AddAsync(product, cancellationToken);
            return Response.Success(newProduct.Adapt<Product, ProductDTO>(), "Product created successfully");
        }
    }
}
