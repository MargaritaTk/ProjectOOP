using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Dish : IOrderable
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public DishType Type { get; set; }

        public void PrintDetails()
        {
            throw new NotImplementedException();
        }
    }
}
