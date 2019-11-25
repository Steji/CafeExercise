using System;
using System.Collections.Generic;

namespace Cafe
{
    public class Menu : IMenu
    {
        public List<Item> Items { get; private set; }
        public List<Item> Selection { get; set; }

        public Menu()
        {
            Items = new List<Item>();
        }

        public void Add(Item item)
        {
            Items.Add(item);
        }

        public void Select(string item)
        {
            throw new NotImplementedException();
        }
    }
}
