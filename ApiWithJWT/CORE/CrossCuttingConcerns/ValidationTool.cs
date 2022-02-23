using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.CrossCuttingConcerns
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object obj)
        {
            //ProductValidator validationRules = new ProductValidator();
            var context = new ValidationContext<object>(obj);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
