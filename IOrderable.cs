using System;

namespace Project
{
    public interface IOrderable
    {
        string Name { get; }
        double Price { get; }
        string PrintDetails();
    }
}
