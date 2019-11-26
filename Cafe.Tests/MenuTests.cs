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
            var item = new Item
            {
                Name = "Vindaloo",
                Temperature = Temperature.Hot,
                Price = 5.50m
            };

            _menu.Object.Add(item);

            Assert.Contains(item, _menu.Object.Items);
        }

        [Fact]
        public void Menu_Selects_Item()
        {
            var item = new Item
            {
                Name = "Vindaloo",
                Temperature = Temperature.Hot,
                Price = 5.50m
            };

            _menu.SetupGet(m => m.Items).Returns(new List<Item> { item });

            _menu.Object.Select("Vindaloo");

            Assert.Contains(item, _menu.Object.Selection);
        }

        [Fact]
        public void Menu_Calculates_Items_Total()
        {
            var vindaloo = new Item
            {
                Name = "Vindaloo",
                Temperature = Temperature.Hot,
                Price = 5.50m
            };

            var bhuna = new Item
            {
                Name = "Bhuna",
                Temperature = Temperature.Hot,
                Price = 5.80m
            };

            var mangoChutney = new Item
            {
                Name = "Mango Chutney",
                Temperature = Temperature.Cold,
                Price = 0.90m
            };

            _menu.SetupGet(m => m.Selection).Returns(new List<Item> { vindaloo, bhuna, mangoChutney });

            var result = _menu.Object.CalculateTotal();

            Assert.Equal(12.20m, result);
        }
    }
}
