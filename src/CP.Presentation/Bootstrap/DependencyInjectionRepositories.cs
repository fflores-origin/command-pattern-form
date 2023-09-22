using CP.Core;
using CP.Data;
using Microsoft.Extensions.DependencyInjection;

namespace CP.Presentation.Bootstrap
{
    internal static class DependencyInjectionRepositories
    {
        public static void AddDependencyInjectionRepositories(this IServiceCollection services)
        {
            services
                .AddTransient<IConnection, DataContext>()
                .AddSingleton<OrdenesRepository>()
                .AddSingleton<CalculatorReceiver>();
        }
    }
}