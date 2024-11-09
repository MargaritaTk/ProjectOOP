using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Drink : IOrderable
    {
        public string Name { get; }
        public double Price { get; }
        public DrinkType Type { get; }

        public Drink(string name, double price, DrinkType type)
        {
            Name = name;
            Price = price;
            Type = type;
        }

        public void PrintDetails()
    {
    }
}
