using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Utilities
{
    public static class ServiceTool
    {
        public static IServiceProvider serviceProvider { get; set; }
        public static IServiceCollection Create(IServiceCollection service)
        {
            serviceProvider = service.BuildServiceProvider();
            return service;
        }
    }
}
