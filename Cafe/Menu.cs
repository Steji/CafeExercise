using System;
using System.Collections.Generic;
using System.Linq;

namespace Cafe
{
    public class Menu : IMenu
    {
        public virtual List<Item> Items { get; private set; }
        public virtual List<Item> Selection { get; set; }

        public Menu()
        {
            Items = new List<Item>();
            Selection = new List<Item>();
        }

        public void Add(Item item)
        {
            Items.Add(item);
        }

        public void Select(string item)
        {
            var itemToAdd = Items.SingleOrDefault(i => i.Name == item);

            if (itemToAdd != null)
                Selection.Add(itemToAdd);
        }
    }
}
