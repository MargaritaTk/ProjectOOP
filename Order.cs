using System;

namespace Project
{
    public class Order
    {
        public List<IOrderable> Items { get; } = new List<IOrderable>();

        public void AddItem(IOrderable item)
        {
            Items.Add(item);
        }

        public void RemoveItem(IOrderable item)
        {
            Items.Remove(item);
        }
    }
}