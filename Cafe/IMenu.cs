using System.Collections.Generic;

namespace Cafe
{
    public interface IMenu
    {
        List<Item> Items { get; }
        List<Item> Selection { get; }

        void Add(Item item);

        void Select(string item);

        decimal CalculateTotal();
    }
}