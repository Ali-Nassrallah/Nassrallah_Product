using NassrallahAPI.Application.DTOs;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NassrallahAPI.Shared.Abstractions.Application.Commands;

namespace NassrallahAPI.Application.Commands.ProductCommand
{
    public record CreateProductCommand(string Name, string Description, decimal Price, int Quantity):ICommand<ProductDTO>;

}
