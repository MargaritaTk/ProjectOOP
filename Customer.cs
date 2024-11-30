﻿using System;
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

        public Customer(string name) : base(name)
        {
            RoleDescription = "Our Customer.";
        }

        public override void Role()
        {
            Console.WriteLine($"{Name} is placing an order.");
        }
        public void PlaceOrder(Order order)
        {
            if (order == null || order.Items.Count == 0)
            {
                throw new InvalidOperationException("Order can't be empty.");
            }

            Orders.Add(order);
        }
    }
}

