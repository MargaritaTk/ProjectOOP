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
            Orders.Add(order);
        }
    }

}
