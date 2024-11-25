using System;

namespace Project
{
    public class Dish : IOrderable
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public DishType Type { get; set; }

        public void PrintDetails()
        {
            throw new NotImplementedException();
        }
    }
}
