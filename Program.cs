using Project;
using System;

class Program
{
    static void Main(string[] args)
    {
        MainMenu();
    }

    static void MainMenu()
    {
        var menu = new Menu();
        menu.MenuUpdates += message => Console.WriteLine($"[Menu Update]: {message}"); // Підписка на подію

        List<Person> people = new List<Person>
        {
            new Waiter("Chris"),
            new Waiter("Liza"),
            new Customer("Lizzi"),
            new Customer("Mary"),
            new Customer("Andrew"),
            new Customer("Sasha"),
            new Customer("Lara"),
            new Customer("Sam"),
        };

        foreach (var person in people)
        {
            Console.WriteLine($"{person.Name}: {person.RoleDescription}");
        }

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add a dish to the menu");
            Console.WriteLine("2. Add a drink to the menu");
            Console.WriteLine("3. View the menu");
            Console.WriteLine("4. Create an order");
            Console.WriteLine("5. View all orders");
            Console.WriteLine("6. Assign a waiter to an order");
            Console.WriteLine("7. Serve an order");
            Console.WriteLine("8. Remove item from an order");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddDish(menu);
                    break;
                case "2":
                    AddDrink(menu);
                    break;
                case "3":
                    ViewMenu(menu);
                    break;
                case "4":
                    AddOrder(menu, people); 
                    break;
                case "5":
                    ViewOrders(people);
                    break;
                case "6":
                    AssignOrderToWaiter(people);
                    break;
                case "7":
                    ServeOrderByWaiter(people);
                    break;
                case "8":
                    RemoveItemFromOrder(people);
                    break;
                case "0":
                    Console.WriteLine("Thank you for visiting our cafe! Exit...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void AddDish(Menu menu)
    {
        Action<string> printAction = Console.WriteLine; // Делегат Action
        string name;
        while (true)
        {
            Console.Write("Enter the name of the dish: ");
            name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                break;
            printAction("Dish name can't be empty. Please try again.");
        }

        double price;
        while (true)
        {
            Console.Write("Enter the price of the dish: ");
            if (double.TryParse(Console.ReadLine(), out price) && price > 0)
                break;
            printAction("Invalid price. Please enter a positive number.");
        }

        DishType dishType;
        while (true)
        {
            Console.WriteLine("Choose the type of the dish:");
            foreach (var type in Enum.GetValues(typeof(DishType)))
            {
                printAction($"- {type}");
            }

            if (Enum.TryParse(Console.ReadLine(), true, out dishType))
                break;
            printAction("Invalid dish type. Please try again.");
        }

        var dish = new Dish { Name = name, Price = price, Type = dishType };
        menu.AddDish(dish);
        printAction("Dish added successfully.");
    }

    static void AddDrink(Menu menu)
    {
        Func<string, double, DrinkType, Drink> createDrink = (name, price, type) => new Drink { Name = name, Price = price, Type = type }; // Делегат Func

        string name;
        while (true)
        {
            Console.Write("Enter the name of the drink: ");
            name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                break;
            Console.WriteLine("Drink name cannot be empty. Please try again.");
        }

        double price;
        while (true)
        {
            Console.Write("Enter the price of the drink: ");
            if (double.TryParse(Console.ReadLine(), out price) && price > 0)
                break;
            Console.WriteLine("Invalid price. Please enter a positive number.");
        }

        DrinkType drinkType;
        while (true)
        {
            Console.WriteLine("Choose the type of the drink:");
            foreach (var type in Enum.GetValues(typeof(DrinkType)))
            {
                Console.WriteLine($"- {type}");
            }

            if (Enum.TryParse(Console.ReadLine(), true, out drinkType))
                break;
            Console.WriteLine("Invalid drink type. Please try again.");
        }

        var drink = createDrink(name, price, drinkType);
        menu.AddDrink(drink);
        Console.WriteLine("Drink added successfully.");
    }

    static void ViewOrders(List<Person> people)
    {
        Console.WriteLine("Customers' Orders:");
        var customers = new List<Customer>();

        foreach (var person in people)
        {
            if (person is Customer customer)
            {
                customers.Add(customer);
            }
        }

        if (customers.Count == 0)
        {
            Console.WriteLine("No customers available.");
            return;
        }

        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.Name}:");
            if (customer.Orders.Count == 0)
            {
                Console.WriteLine("  No orders placed.");
            }
            else
            {
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"  Order {customer.Orders.IndexOf(order) + 1}:");
                    foreach (var item in order.Items)
                    {
                        Console.WriteLine($"    - {item.Name}: {item.Price} UAH");
                    }
                }
            }
        }
    }

    static void AddOrder(Menu menu, List<Person> people)
    {
        Customer customer = null;

        while (true)
        {
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();

            foreach (var person in people)
            {
                if (person is Customer c && c.Name.Equals(customerName, StringComparison.OrdinalIgnoreCase))
                {
                    customer = c;
                    break;
                }
            }

            if (customer != null)
                break;

            Console.WriteLine($"Error: We don't have a customer with the name '{customerName}'. Please try again.");
        }

        var order = new Order();
        Console.WriteLine("Add items to the order (type 'done' to finish):");

        while (true)
        {
            Console.Write("Enter item name: ");
            string itemName = Console.ReadLine();

            if (itemName.Equals("done", StringComparison.OrdinalIgnoreCase))
                break;

            IOrderable item = null;

            foreach (var dish in menu.Dishes)
            {
                if (dish.Name.Equals(itemName))
                {
                    item = dish;
                    break;
                }
            }

            if (item == null)
            {
                foreach (var drink in menu.Drinks)
                {
                    if (drink.Name.Equals(itemName))
                    {
                        item = drink;
                        break;
                    }
                }
            }

            if (item != null)
            {
                order.AddItem(item);
                Console.WriteLine($"{item.Name} added to the order.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Item not found in menu. Please try again.");
                Console.WriteLine();
            }
        }

        try
        {
            customer.PlaceOrder(order);
            Console.WriteLine("Order added successfully.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ViewMenu(Menu menu)
    {
        Console.WriteLine(menu.PrintMenu());
    }

    static void AssignOrderToWaiter(List<Person> people)
    {
        Customer customer = null;
        while (true)
        {
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();

            foreach (var person in people)
            {
                if (person is Customer c && c.Name.Equals(customerName))
                {
                    customer = c;
                    break;
                }
            }

            if (customer != null && customer.Orders.Count > 0)
                break;

            Console.WriteLine("No orders found for this customer or customer does not exist. Please try again.");
        }

        while (true)
        {
            Console.Write("Enter order index: ");
            if (int.TryParse(Console.ReadLine(), out int orderIndex) && orderIndex > 0 && orderIndex <= customer.Orders.Count)
            {
                var order = customer.Orders[orderIndex - 1];
                Console.WriteLine("Available waiters:");
                var waiters = new List<Waiter>();

                foreach (var person in people)
                {
                    if (person is Waiter waiter)
                    {
                        waiters.Add(waiter);
                    }
                }

                for (int i = 0; i < waiters.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {waiters[i].Name}");
                }

                while (true)
                {
                    Console.Write("Choose waiter index: ");
                    if (int.TryParse(Console.ReadLine(), out int waiterIndex) && waiterIndex > 0 && waiterIndex <= waiters.Count)
                    {
                        var waiter = waiters[waiterIndex - 1];
                        Console.WriteLine(waiter.TakeOrder(order));
                        Console.WriteLine("The waiter took the order.");
                        return; 
                    }
                    else
                    {
                        Console.WriteLine("Invalid waiter index. Please try again.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid order index. Please try again.");
            }
        }
    }

    static void ServeOrderByWaiter(List<Person> people)
    {
        var waiters = new List<Waiter>();

        foreach (var person in people)
        {
            if (person is Waiter waiter)
            {
                waiters.Add(waiter);
            }
        }

        if (waiters.Count == 0)
        {
            Console.WriteLine("No waiters available.");
            return;
        }

        while (true)
        {
            Console.WriteLine("Available waiters:");
            for (int i = 0; i < waiters.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {waiters[i].Name}");
            }

            Console.Write("Choose a waiter by index: ");
            if (int.TryParse(Console.ReadLine(), out int waiterIndex) && waiterIndex >= 1 && waiterIndex <= waiters.Count)
            {
                var waiter = waiters[waiterIndex - 1];
                var activeOrders = waiter.GetActiveOrders();

                if (activeOrders.Count == 0)
                {
                    Console.WriteLine("This waiter has no active orders.");
                    continue;
                }

                while (true)
                {
                    Console.WriteLine("Active orders:");
                    for (int i = 0; i < activeOrders.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Order with {activeOrders[i].Items.Count} items.");
                    }

                    Console.Write("Enter order index to serve (1 to N): ");
                    if (int.TryParse(Console.ReadLine(), out int orderIndex) && orderIndex >= 1 && orderIndex <= activeOrders.Count)
                    {
                        var order = activeOrders[orderIndex - 1];
                        waiter.ServeOrder(order);
                        Console.WriteLine("Order has been served.");

                        foreach (var person in people)
                        {
                            if (person is Customer customer && customer.Orders.Contains(order))
                            {
                                customer.Orders.Remove(order);
                                Console.WriteLine($"Order removed from customer {customer.Name}'s list.");
                                break;
                            }
                        }
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid order index. Please try again.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid waiter index. Please try again.");
            }
        }
    }

    static void RemoveItemFromOrder(List<Person> people)
    {
        Customer customer = null;
        while (true)
        {
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();

            foreach (var person in people)
            {
                if (person is Customer c && c.Name.Equals(customerName))
                {
                    customer = c;
                    break;
                }
            }

            if (customer != null && customer.Orders.Count > 0)
                break;

            Console.WriteLine("No orders found for this customer or customer does not exist. Please try again.");
        }

        while (true)
        {
            Console.Write("Enter order index to modify (1 to N): ");
            if (int.TryParse(Console.ReadLine(), out int orderIndex) && orderIndex >= 1 && orderIndex <= customer.Orders.Count)
            {
                var order = customer.Orders[orderIndex - 1];

                while (true)
                {
                    Console.WriteLine("Items in the order:");
                    for (int i = 0; i < order.Items.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {order.Items[i].Name} ({order.Items[i].Price} UAH)");
                    }

                    Console.Write("Enter item index to remove (1 to N): ");
                    if (int.TryParse(Console.ReadLine(), out int itemIndex) && itemIndex >= 1 && itemIndex <= order.Items.Count)
                    {
                        var item = order.Items[itemIndex - 1];
                        order.RemoveItem(item);
                        Console.WriteLine($"{item.Name} has been removed from the order.");
                        return; 
                    }
                    else
                    {
                        Console.WriteLine("Invalid item index. Please try again.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid order index. Please try again.");
            }
        }
    }
}
