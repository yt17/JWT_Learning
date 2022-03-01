using CORE.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.DepencyResolver
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceProvider)
        {
            serviceProvider.AddMemoryCache();
        }
    }
}
