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

        public Waiter(string name)
        {
            Name = name;
        }

        public void TakeOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void ServeOrder(Order order)
    {
    }
}
