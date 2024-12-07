using Project;
using System;

namespace Project
{
    public class Dish : IOrderable, IComparable<Dish>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public DishType Type { get; set; }

        public int CompareTo(Dish other)
        {
            if (other == null) return 1;

            return this.Price.CompareTo(other.Price); 
        }
        public string PrintDetails()
        {
            return $"Dish: {Name}, Type: {Type}, Price: {Price} UAH";
        }
    }
}

   

    