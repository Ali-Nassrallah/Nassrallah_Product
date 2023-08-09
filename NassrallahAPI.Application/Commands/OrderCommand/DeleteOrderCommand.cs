using MediatR;
using NassrallahAPI.Shared.Abstractions.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Application.Commands.OrderCommand
{
    public record DeleteOrderCommand(int Id):ICommand<Unit>;
}
