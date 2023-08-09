using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NassrallahAPI.Application.DTOs
{
    public record ProductDTO(int Id,string Name,string Description,decimal Price,int Quantity,OrderDTO Order);
}
