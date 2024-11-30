using Project;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Project
{
    public class Drink : IComparable<Drink>, IOrderable
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public DrinkType Type { get; set; }

        public int CompareTo(Drink other)
        {
            if (other == null) return 1;

            return this.Price.CompareTo(other.Price); 
        }


        public void PrintDetails()
        {
            Console.WriteLine($"Drink: {Name}, Type: {Type}, Price: {Price} UAH");

        }
    }
}
    

    