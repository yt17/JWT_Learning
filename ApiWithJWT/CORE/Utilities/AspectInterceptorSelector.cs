using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace CORE.Utilities
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterCeptionBaseAttr>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterCeptionBaseAttr>(true);
            classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
