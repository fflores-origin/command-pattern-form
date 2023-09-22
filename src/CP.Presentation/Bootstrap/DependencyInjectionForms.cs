using CP.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Presentation.Bootstrap
{
    internal static class DependencyInjectionForms
    {
        public static void AddDependencyInjectionForms(this IServiceCollection services)
        {
            services
                .AddTransient<Main>();
            //    .AddTransient<IArticuloRepository, ArticuloRepository>();
        }
    }
}
