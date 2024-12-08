using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Customer : Person
    {
        public List<Order> Orders { get; } = new List<Order>();
        public override string RoleDescription { get; set; }

        public event Action<string>? OrderCreated;

        public Customer(string name) : base(name)
        {
            RoleDescription = "Our Customer.";
        }

        public override void Role()
        {
            Console.WriteLine($"{Name} is placing an order.");
        } public void PlaceOrder(Order order)
        {
            Role();

            if (order == null || order.Items.Count == 0)
            {
                throw new InvalidOperationException("Order can't be empty.");
            }
            Orders.Add(order);
            Console.WriteLine();
            OrderCreated?.Invoke($"Order created for customer {Name}.");
        }
    }
}

