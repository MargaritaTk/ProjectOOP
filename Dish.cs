using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Dish : IOrderable
    {
        public string Name { get; }
        public double Price { get; }
        public DishType Type { get; }

        public Dish(string name, double price, DishType type)
        {
            Name = name;
            Price = price;
            Type = type;
        }

        public void PrintDetails()
    {
    }
}
