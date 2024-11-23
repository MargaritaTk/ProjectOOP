using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class Drink : MenuItem, ICloneable
    {
        public override string Name { get; set; }
        public override double Price { get; set; }
        public DrinkType Type { get; set; }

        public override void PrintDetails()
        {
            Console.WriteLine($"Drink: {Name}, Price: {Price:F2}, Type: {Type}");
        }


        public object Clone()
        {
            return new Drink
            {
                Name = this.Name,
                Price = this.Price,
                Type = this.Type
            };
        }
    }

}
