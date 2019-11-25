using Xunit;
using Moq;
using System.Collections.Generic;

namespace Cafe.Tests
{
    public class MenuTests
    {
        private readonly Mock<Menu> _menu;

        public MenuTests()
        {
            _menu = new Mock<Menu>();

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
    }
}
