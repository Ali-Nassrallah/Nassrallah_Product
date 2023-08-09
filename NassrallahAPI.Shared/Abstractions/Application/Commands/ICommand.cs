﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Shared.Abstractions.Application.Commands
{
    public interface ICommand<T> : IRequest<Response<T>> { }
}
