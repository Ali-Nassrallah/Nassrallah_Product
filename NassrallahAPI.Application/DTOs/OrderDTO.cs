using NassrallahAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Application.DTOs
{
    public record OrderDTO(int Id,DateTime OrderDate, decimal TotalAmount, List<Product> Products);
}
