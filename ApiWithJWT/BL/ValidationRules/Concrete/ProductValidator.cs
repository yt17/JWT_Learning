using Entities;
using FluentValidation;
using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.ValidationRules.Concrete
{
    public class ProductValidator:AbstractValidator<ProductDTO>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ID).LessThanOrEqualTo(0);
            RuleFor(p => p.Name).Length(2,40).WithMessage("karakter sayisina takildiniz");               
        }
    }
}
