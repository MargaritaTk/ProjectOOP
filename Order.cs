using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
