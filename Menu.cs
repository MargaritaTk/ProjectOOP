using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Menu : IPrintable
    {
        public List<Dish> Dishes { get; } = new List<Dish>();
        public List<Drink> Drinks { get; } = new List<Drink>();

        public void AddDish(Dish dish)
        {
            Dishes.Add(dish);
        }

        public void AddDrink(Drink drink)
        {
            Drinks.Add(drink);
        }

        public void PrintMenu()
        {
            throw new NotImplementedException();
        }

        public void PrintReceipt()
        {
            throw new NotImplementedException();
        }
    }
}