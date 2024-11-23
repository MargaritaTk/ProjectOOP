using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Customer
    {
        public string Name { get; }
        public List<Order> Orders { get; }

        public Customer(string name)
        {
            Name = name;
            Orders = new List<Order>();
        }

        public void PlaceOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");
            }

            if (order.Items.Count == 0)
            {
                throw new InvalidOperationException("Order must contain at least one item.");
            }

            Orders.Add(order);
        }
    }

}
