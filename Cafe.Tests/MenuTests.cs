using Xunit;
using Moq;
using System.Collections.Generic;

namespace Cafe.Tests
{
    public class MenuTests
    {
        private readonly Mock<IMenu> _menu;

        public MenuTests()
        {
            _menu = new Mock<Menu>().As<IMenu>();

            _menu.CallBase = true;
        }

        [Fact]
        public void Menu_Adds_Item()
        {
            var item = new Item("Vindaloo", Temperature.Hot, 5.50m, Sustenance.Food);

            _menu.Object.Add(item);

            Assert.Contains(item, _menu.Object.Items);
        }

        [Fact]
        public void Menu_Selects_Item()
        {
            var item = new Item("Vindaloo", Temperature.Hot, 5.50m, Sustenance.Food);

            _menu.SetupGet(m => m.Items).Returns(new List<Item> { item });

            _menu.Object.Select("Vindaloo");

            Assert.Contains(item, _menu.Object.Selection);
        }

        [Fact]
        public void Menu_Calculates_Items_Total_No_Service_Charge_Drinks_Only()
        {
            var coffee = new Item("Coffee", Temperature.Hot, 2.50m, Sustenance.Drink);

            var tea = new Item("Tea", Temperature.Hot, 1.80m, Sustenance.Drink);

            _menu.SetupGet(m => m.Selection).Returns(new List<Item> { coffee, tea });

            var result = _menu.Object.CalculateTotal();

            Assert.Equal(4.30m, result);
        }

        [Fact]
        public void Menu_Calculates_Items_Total_Ten_Percent_Service_Charge_With_Cold_Food_Rounding_Down()
        {
            var coffee = new Item("Coffee", Temperature.Hot, 2.55m, Sustenance.Drink);

            var tea = new Item("Tea", Temperature.Hot, 1.89m, Sustenance.Drink);

            var cake = new Item("Cake", Temperature.Cold, 3.00m, Sustenance.Food);

            _menu.SetupGet(m => m.Selection).Returns(new List<Item> { coffee, tea, cake });

            var result = _menu.Object.CalculateTotal();

            Assert.Equal(8.18m, result);
        }

        [Fact]
        public void Menu_Calculates_Items_Total_Twenty_Percent_Service_Charge_With_Hot_Food_Rounding_Up()
        {
            var coffee = new Item("Coffee", Temperature.Hot, 2.55m, Sustenance.Drink);

            var tea = new Item("Tea", Temperature.Hot, 1.89m, Sustenance.Drink);

            var cake = new Item("Cake", Temperature.Cold, 3.00m, Sustenance.Food);

            var soup = new Item("Soup", Temperature.Hot, 3.25m, Sustenance.Food);

            _menu.SetupGet(m => m.Selection).Returns(new List<Item> { coffee, tea, cake, soup });

            var result = _menu.Object.CalculateTotal();

            Assert.Equal(12.83m, result);
        }

        [Fact]
        public void Menu_Calculates_Items_Total_Twenty_Percent_Service_Charge_With_Hot_Food_Max_Twenty_Pounds()
        {
            var coffee = new Item("Coffee", Temperature.Hot, 2.55m, Sustenance.Drink);

            var tea = new Item("Tea", Temperature.Hot, 1.89m, Sustenance.Drink);

            var cake = new Item("Cake", Temperature.Cold, 3.00m, Sustenance.Food);

            var soup = new Item("Soup", Temperature.Hot, 3.25m, Sustenance.Food);

            var krug = new Item("Krug", Temperature.Cold, 100m, Sustenance.Drink);

            _menu.SetupGet(m => m.Selection).Returns(new List<Item> { coffee, tea, cake, soup, krug });

            var result = _menu.Object.CalculateTotal();

            Assert.Equal(130.69m, result);
        }
    }
}
