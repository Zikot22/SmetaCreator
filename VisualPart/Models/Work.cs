using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmetaCreator.Models
{
    public class Work
    {
        private double price;
        private int amount;
        public string? Name { get; set; }
        public double Price
        {
            get
            {
                return price;
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
                return amount;
            }
            set
            {
                if (value > 0)
                {
                    amount = value;
                }
            }
        }
        public double TotalPrice { get { return Price * Amount; } }

        public Work(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public Work() { }

        public string ListBoxView()
        {
            return $"{Name} {Price} руб в объёме {Amount}. Стоимость: {TotalPrice} руб";
        }

        public Work Clone(int amount)
        {
            Work work = new Work(this.Name!, this.Price);
            work.Amount = amount;
            return work;
        }
    }
}
