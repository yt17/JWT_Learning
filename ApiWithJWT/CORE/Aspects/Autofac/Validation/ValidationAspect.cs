using Castle.DynamicProxy;
using CORE.Utilities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CORE.CrossCuttingConcerns;

namespace CORE.Aspects.Autofac.Validation
{
    public class ValidationAspect: MethodInterceptors
    {
        private Type validatorType;
        public ValidationAspect(Type validatorType)
        {

            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("wrong Type");
            }
            this.validatorType = validatorType;

        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(validatorType);
            var entityType = validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(z => z.GetType() == entityType);
            foreach (var item in entities)
            {
                ValidationTool.Validate(validator, item);
            }
            //base.OnBefore();
        }
    }
}
