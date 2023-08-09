using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NassrallahAPI.Domain.Entities;

namespace NassrallahAPI.Domain.Validations
{
    public class OrderValidator: AbstractValidator<Order>
    {
        public OrderValidator() 
        {
          RuleFor(d=>d.TotalAmount).NotEmpty().LessThan(1).WithMessage("At least 1");
        }
    }
}
