using System.Collections.Generic;

namespace Cafe
{
    public interface IMenu
    {
        IEnumerable<Item> Items { get; }

        void Add(Item item);
    }
}