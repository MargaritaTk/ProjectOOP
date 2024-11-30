using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Waiter : Person
    {
        public override string RoleDescription { get; set; }

        public Waiter(string name) : base(name)
        {
            RoleDescription = "Your Waiter.";
        }

        private List<Order> ActiveOrders { get; set; } = new List<Order>();

        public override void Role()
        {
            Console.WriteLine($"{Name} is serving orders.");
        }

        public void TakeOrder(Order order)
        {
            if (order == null)
            {
                Console.WriteLine("Invalid order. Can't be null.");
                return;
            }
            Role();
            ActiveOrders.Add(order);
            Console.WriteLine($"Waiter {Name} has taken the order with {order.Items.Count} items.");
        }

        public void ServeOrder(Order order)
        {
            if (order == null)
            {
                Console.WriteLine("Invalid order. Can't be null.");
                return;
            }
            Role();

            if (ActiveOrders.Contains(order))
            {
                ActiveOrders.Remove(order);
                Console.WriteLine($"Waiter {Name} has served the order successfully.");
            }
            else
            {
                Console.WriteLine($"The order is not found in {Name}'s active orders.");
            }
        }

        public void PrintActiveOrders()
        {
            if (ActiveOrders.Count == 0)
            {
                Console.WriteLine($"Waiter {Name} currently has no active orders.");
            }
            else
            {
                Console.WriteLine($"Waiter {Name}'s active orders:");
                for (int i = 0; i < ActiveOrders.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Order with {ActiveOrders[i].Items.Count} items.");
                }
            }
        }
        public List<Order> GetActiveOrders()
        {
            return new List<Order>(ActiveOrders);
        }
    }
}
