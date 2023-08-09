using MediatR;
using NassrallahAPI.Application.DTOs;
using NassrallahAPI.Shared.Abstractions.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Application.Queries.ProductQueries
{
    public record GetProductByIdQuery(int Id):IQuery<ProductDTO>;
}
