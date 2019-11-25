using System.Collections.Generic;

namespace Cafe
{
    public interface IMenu
    {
        List<Item> Items { get; }

        void Add(Item item);
    }
}