using System;
using System.Collections.Generic;

namespace Cafe
{
    public class Menu : IMenu
    {
        public List<Item> Items { get; private set; }

        public Menu()
        {
            Items = new List<Item>();
        }

        public void Add(Item item)
        {
            Items.Add(item);
        }
    }
}
