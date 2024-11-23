using System;

namespace Project
{
    public abstract class MenuItem : IOrderable
    {
        public abstract string Name { get; set; }
        public abstract double Price { get; set; }

        public abstract void PrintDetails();
    }
}
