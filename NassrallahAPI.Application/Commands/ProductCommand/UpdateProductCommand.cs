using MediatR;
using NassrallahAPI.Application.DTOs;
using NassrallahAPI.Shared.Abstractions.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Application.Commands.ProductCommand
{
    public record UpdateProductCommand(int Id, string Name,string Description,decimal Price,int Quantity) : ICommand<ProductDTO>;
    
}
