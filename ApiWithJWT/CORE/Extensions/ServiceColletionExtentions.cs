using CORE.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Extensions
{
    public static class ServiceColletionExtentions
    {
        public static IServiceCollection addDependencyResolvers(this IServiceCollection services,
            ICoreModule[] modules)
        {
            foreach (var item in modules)
            {
                item.Load(services);
            }
            return ServiceTool.Create(services);
        }
    }
}
