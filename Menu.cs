using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    using System.Collections.Generic;

    public class Menu : IPrintable
    {
        public List<DishType> Dishes { get; }
        public List<DrinkType> Drinks { get; }

        public Menu()
        {
            Dishes = new List<DishType>();
            Drinks = new List<DrinkType>();
        }

        public void AddDish(DishType dish)
        {
            Dishes.Add(dish);
        }

        public void AddDrink(DrinkType drink)
        {
            Drinks.Add(drink);
        }

        public void PrintMenu()
        {
            throw new NotImplementedException();
        }

        public void PrintReceipt()
    {
    }
}
