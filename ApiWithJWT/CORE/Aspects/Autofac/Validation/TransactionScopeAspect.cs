using Castle.DynamicProxy;
using CORE.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace CORE.Aspects.Autofac.Validation
{
    public class TransactionScopeAspect: MethodInterceptors
    {
        public override void Intercept(IInvocation invocation)
        {
            //base.Intercept(invocation);
            using (TransactionScope transactionScope=new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception ex)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
