//using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Utilities
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple =true,Inherited =true)]
    public abstract class MethodInterCeptionBaseAttr:Attribute,IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {
            
        }
    }
}
