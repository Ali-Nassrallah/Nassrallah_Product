using MediatR;
using NassrallahAPI.Application.Repositories;
using NassrallahAPI.Shared;
using NassrallahAPI.Shared.Abstractions.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
namespace NassrallahAPI.Application.Commands.ProductCommand.Handlers
{
    public class DeleteProductHandler :  ICommandHandler<DeleteProductCommand ,Unit>
    {
        private readonly IProductRepository _repository;
        public DeleteProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Unit>> Handle(DeleteProductCommand request,CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id, cancellationToken);
            return Response.Success(Unit.Value, "Deleted Product");
        }
    }
}
