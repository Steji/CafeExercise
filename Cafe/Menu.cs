using System;
using System.Collections.Generic;

namespace Cafe
{
    public class Menu : IMenu
    {
        public IEnumerable<Item> Items => throw new NotImplementedException();

        public void Add(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
