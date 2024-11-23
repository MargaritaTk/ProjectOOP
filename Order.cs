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

        public void PrintOrder()
        {
            if (Items.Count == 0)
            {
                Console.WriteLine("Order is empty.");
                return;
            }

            Console.WriteLine("Order contains the following items:");
            foreach (var item in Items)
            {
                item.PrintDetails();
            }
        }
    }
}