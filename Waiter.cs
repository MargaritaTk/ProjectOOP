using System;
using System.Collections.Generic;
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

        public string TakeOrder(Order order)
        {
            if (order == null) return "Invalid order. Can't be null.";

            Role();
            ActiveOrders.Add(order);
            return $"Waiter {Name} has taken the order with {order.Items.Count} items.";
        }

        public string ServeOrder(Order order)
        {
            if (order == null) return "Invalid order. Can't be null.";

            Role();
            if (ActiveOrders.Contains(order))
            {
                ActiveOrders.Remove(order);
                return $"Waiter {Name} has served the order successfully.";
            }
            else
            {
                return $"The order is not found in {Name}'s active orders.";
            }
        }

        public string PrintActiveOrders()
        {
            if (ActiveOrders.Count == 0)
            {
                return $"Waiter {Name} currently has no active orders.";
            }

            var builder = new StringBuilder($"Waiter {Name}'s active orders:\n");
            for (int i = 0; i < ActiveOrders.Count; i++)
            {
                builder.AppendLine($"{i + 1}. Order with {ActiveOrders[i].Items.Count} items.");
            }
            return builder.ToString();
        }

        public List<Order> GetActiveOrders()
        {
            return new List<Order>(ActiveOrders);
        }
    }
}

