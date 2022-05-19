using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmetaCreator.Models
{
    internal class Work
    {
        public double price;
        public string? Name { get; set; }
        public double Price
        {
            get
            {
                return Price;
            }
            set
            {
                if (value > 0)
                {
                    price = value;
                }
            }
        }
        public int Amount
        {
            get
            {
                return Amount;
            }
            set
            {
                if (value > 0)
                {
                    Amount = value;
                }
            }
        }
        private double TotalPrice { get { return Price * Amount; } }

        public Work(string name, double price)
        {
            Name = name;
            Price = price;
        }

        private string ListBoxView()
        {
            return $"{Name} {Price} рублей в количестве {Amount}. Стоимость: {TotalPrice}";
        }
    }
}
