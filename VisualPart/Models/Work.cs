using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmetaCreator.Models
{
    internal class Work
    {
        private string? Name { get; set; }
        private double Price { get; set; }
        private int Amount { get; set; }
        private double TotalPrice { get; set; }

        public Work(string name, double price)
        {
            Name = name;
            Price = price;
        }

        private void PriceCount(int amount)
        {
            Amount = amount;
            TotalPrice = Price * Amount;
        }

        private string ListBoxView()
        {
            return $"{Name} {Price} рублей в количестве {Amount}. Стоимость: {TotalPrice}";
        }
    }
}
