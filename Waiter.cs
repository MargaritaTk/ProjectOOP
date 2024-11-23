using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Waiter
    {
        public string Name { get; }
        public List<Order> ActiveOrders { get; } = new List<Order>();

        public Waiter(string name)
        {
            Name = name;
        }

        // Метод для додавання активного замовлення
        public void TakeOrder(Order order)
        {
            ActiveOrders.Add(order);
        }

        // Метод для обслуговування замовлення
        public void ServeOrder(Order order)
        {
            ActiveOrders.Remove(order);
            Console.WriteLine($"Order for {order} has been served by {Name}.");
        }

        // Додатковий метод для виведення активних замовлень
        public void PrintActiveOrders()
        {
            if (ActiveOrders.Count == 0)
            {
                Console.WriteLine("No active orders.");
                return;
            }

            for (int i = 0; i < ActiveOrders.Count; i++)
            {
                var order = ActiveOrders[i];
                Console.WriteLine($"{i + 1}. Order: {string.Join(", ", order.Items.Select(item => item.Name))}");
            }
        }
    }
}
