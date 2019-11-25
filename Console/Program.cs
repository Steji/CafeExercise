using Cafe;
using Microsoft.Extensions.DependencyInjection;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            var menu = serviceProvider.GetService<IMenu>();

            //menu.add
            //menu.select
            //menu.total
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IMenu, Menu>();

            return services;
        }
    }
}
