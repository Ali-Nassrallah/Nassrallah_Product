
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

namespace NassrallahAPI.Application.Commands.ProductCommand.Handlers
{
    public class UpdateProductHandler : ICommandHandler<UpdateProductCommand,ProductDTO>
    {
        private readonly IProductRepository _repository;
        private readonly IValidator<Product> _validator;
        public UpdateProductHandler(IProductRepository repository,IValidator<Product> validator)
        {
               _repository = repository;
               _validator = validator;
        }
        public async Task<Response<ProductDTO>> Handle(UpdateProductCommand request,CancellationToken cancellationToken)
        {
            var (Id, Name, Description, Price, Quantity) = request;
            var product = await _repository.GetWholeByIdAsync(Id, cancellationToken);
            product.Update(Name, Description, Price, Quantity);
            var valid = await _validator.ValidateAsync(product);
            if (!valid.IsValid)
                throw new ValidationException(valid.Errors);
            await _repository.UpdateAsync(product, cancellationToken);
            return Response.Success(product.Adapt<Product, ProductDTO>(),"Product updated successfully");
        }
    }
}
