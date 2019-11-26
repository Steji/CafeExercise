using System.Linq;
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

            menu.Add(new Item { Name = "Cola", Temperature = Temperature.Cold, Price = 0.5m });
            menu.Add(new Item { Name = "Coffee", Temperature = Temperature.Hot, Price = 1.0m });
            menu.Add(new Item { Name = "Cheese Sandwich", Temperature = Temperature.Cold, Price = 2.0m });
            menu.Add(new Item { Name = "Steak Sandwich", Temperature = Temperature.Hot, Price = 4.50m });

            System.Console.WriteLine("Please enter order separated with commas (e.g. Cola, Cheese Sandwich) ");
            var input = System.Console.ReadLine();

            foreach (var item in input.Split(","))
                menu.Select(item.Trim());

            var total = menu.CalculateTotal().ToString("0.00");

            System.Console.WriteLine("Your total is: £{0}", total);

            System.Console.WriteLine("Thank you! (Press enter to finish...)");
            System.Console.ReadLine();

            //Not in spec but should have some validation when item is being ordered off menu
            //Selection should probably be case insensitive
            //Should have a nice UI not a console
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IMenu, Menu>();

            return services;
        }
    }
}
