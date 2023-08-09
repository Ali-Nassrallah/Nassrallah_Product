using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MediatR;
using NassrallahAPI.Shared.Abstractions.Application.Commands;
using NuGet.Protocol.Core.Types;

namespace NassrallahAPI.Application.Commands.ProductCommand
{
    public record DeleteProductCommand(int Id) :ICommand<Unit>;
}
