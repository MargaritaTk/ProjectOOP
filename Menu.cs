using System;

namespace Project
{
    public class Menu : IPrintable
    {
        public List<Dish> Dishes { get; } = new List<Dish>();
        public List<Drink> Drinks { get; } = new List<Drink>();

        public delegate void MenuUpdated (string message);


        public event MenuUpdated MenuUpdates; // Подія

        public void AddDish(Dish dish)
        {
            Dishes.Add(dish);
            Dishes.Sort();
            MenuUpdates?.Invoke($"Dish {dish.Name} added to the menu."); // Виклик події
        }


        public void AddDrink(Drink drink)
        {
            Drinks.Add(drink);
            Drinks.Sort();
            MenuUpdates?.Invoke($"Drink {drink.Name} added to the menu."); // Виклик події
        }

        public void SortDrinks()
        {
            Drinks.Sort();
        }
        public void SortDishes()
        {
            Dishes.Sort();
        }

        public string PrintMenu()
        {
            string menu = "=== Menu ===\nDishes:\n";
            foreach (var dish in Dishes)
            {
                menu += dish.PrintDetails() + "\n";
            }

            menu += "Drinks:\n";
            foreach (var drink in Drinks)
            {
                menu += drink.PrintDetails() + "\n";
            }

            return menu;
        }
    }
}