using MediatR;
using NassrallahAPI.Application.DTOs;
using NassrallahAPI.Domain.Entities;
using NassrallahAPI.Shared.Abstractions.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NassrallahAPI.Application.Commands.OrderCommand
{
    public record CreateOrderCommand(int TotalAmmount,List<int> ProductIds):ICommand<OrderDTO>;
}
