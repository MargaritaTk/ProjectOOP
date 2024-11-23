using System;

namespace Project
{
    public class Dish : MenuItem, IComparable<Dish>, ICloneable
    {
        public override string Name { get; set; }
        public override double Price { get; set; }
        public DishType Type { get; set; }

        public override void PrintDetails()
        {
            Console.WriteLine($"Dish: {Name}, Price: {Price:F2}, Type: {Type}");
        }

        public int CompareTo(Dish? other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }

        public object Clone()
        {
            return new Dish
            {
                Name = this.Name,
                Price = this.Price,
                Type = this.Type
            };
        }
    }

}
