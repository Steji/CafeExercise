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

        public decimal CalculateTotal()
        {
            var total = Selection.Sum(s => s.Price);

            total += CalculateServiceCharge(total);

            return total;
        }

        private decimal CalculateServiceCharge(decimal total)
        {
            var serviceCharge = 0.0m;

            if (Selection.Any(s => s.Sustenance == Sustenance.Food && s.Temperature == Temperature.Hot))
                serviceCharge = total * 0.2m;
            else if (Selection.Any(s => s.Sustenance == Sustenance.Food))
                serviceCharge = total * 0.1m;

            serviceCharge = serviceCharge <= 20m ? serviceCharge : 20m;

            return Math.Round(serviceCharge, 2);
        }
    }
}
