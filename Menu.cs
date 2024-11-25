using System;

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
            Console.WriteLine("=== Menu ===");
            Console.WriteLine("Dishes:");
            foreach (var dish in Dishes)
            {
                dish.PrintDetails();
            }
            Console.WriteLine("Drinks:");
            foreach (var drink in Drinks)
            {
                drink.PrintDetails();
            }
        }
    }
}