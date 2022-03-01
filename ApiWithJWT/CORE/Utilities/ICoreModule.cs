using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Utilities
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceProvider);
    }
}
