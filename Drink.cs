using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class Drink : IOrderable
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public DrinkType Type { get; set; }

        public void PrintDetails()
        {
            throw new NotImplementedException();
        }
    }
}
