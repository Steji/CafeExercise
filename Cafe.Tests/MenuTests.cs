using Xunit;

namespace Cafe.Tests
{
    public class MenuTests
    {
        private readonly Menu _menu;

        public MenuTests()
        {
            _menu = new Menu();
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

            _menu.Add(item);

            Assert.Contains(item, _menu.Items);
        }
    }
}
