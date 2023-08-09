using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NassrallahAPI.Domain.Entities;

namespace NassrallahAPI.Domain.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() 
        {
            RuleFor(d => d.Name).NotEmpty().MinimumLength(3).MaximumLength(20).WithMessage("Name required with length btw 3 & 20");
            RuleFor(d=>d.Description).NotEmpty().MinimumLength(15).WithMessage("Description is required with length > 15 characters");
        }
    }
}
