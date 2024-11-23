using Project;

class Program
{
    static void Main(string[] args)
    {
        MainMenu();
    }

    static void MainMenu()
    {
        var menu = new Menu();
        var customers = new List<Customer>();
        var waiters = new List<Waiter> { new Waiter("John"), new Waiter("Emma") };

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
            Console.WriteLine("8. Exit");
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
                    menu.PrintMenu();
                    break;
                case "4":
                    AddOrder(menu, customers);
                    break;
                case "5":
                    ViewOrders(customers);
                    break;
                case "6":
                    AssignOrderToWaiter(customers, waiters);
                    break;
                case "7":
                    ServeOrderByWaiter(waiters);
                    break;
                case "8":
                    Console.WriteLine("Exiting the program...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void AddDish(Menu menu)
    {
        Console.Write("Enter the name of the dish: ");
        string name = Console.ReadLine();

        Console.Write("Enter the price of the dish: ");
        if (!double.TryParse(Console.ReadLine(), out double price) || price <= 0)
        {
            Console.WriteLine("Invalid price.");
            return;
        }

        Console.WriteLine("Choose the type of the dish:");
        foreach (var type in Enum.GetValues(typeof(DishType)))
        {
            Console.WriteLine($"- {type}");
        }

        if (!Enum.TryParse(Console.ReadLine(), out DishType dishType))
        {
            Console.WriteLine("Invalid dish type.");
            return;
        }

        var dish = new Dish { Name = name, Price = price, Type = dishType };
        menu.AddDish(dish);
        Console.WriteLine("Dish added successfully.");
    }

    static void AddDrink(Menu menu)
    {
        Console.Write("Enter the name of the drink: ");
        string name = Console.ReadLine();

        Console.Write("Enter the price of the drink: ");
        if (!double.TryParse(Console.ReadLine(), out double price) || price <= 0)
        {
            Console.WriteLine("Invalid price.");
            return;
        }

        Console.WriteLine("Choose the type of the drink:");
        foreach (var type in Enum.GetValues(typeof(DrinkType)))
        {
            Console.WriteLine($"- {type}");
        }

        if (!Enum.TryParse(Console.ReadLine(), out DrinkType drinkType))
        {
            Console.WriteLine("Invalid drink type.");
            return;
        }

        var drink = new Drink { Name = name, Price = price, Type = drinkType };
        menu.AddDrink(drink);
        Console.WriteLine("Drink added successfully.");
    }

    static void ViewOrders(List<Customer> customers)
    {
        Console.WriteLine("Customers' Orders:");
        if (customers.Count == 0)
        {
            Console.WriteLine("No customers available.");
            return;
        }

        for (int i = 0; i < customers.Count; i++)
        {
            var customer = customers[i];
            Console.WriteLine($"{i + 1}. Customer: {customer.Name}");

            if (customer.Orders.Count == 0)
            {
                Console.WriteLine("  No orders placed.");
            }
            else
            {
                for (int j = 0; j < customer.Orders.Count; j++)
                {
                    var order = customer.Orders[j];
                    Console.WriteLine($"  Order {j + 1}:");
                    foreach (var item in order.Items)
                    {
                        Console.WriteLine($"    - {item.Name}, {item.Price} UAH");
                    }
                }
            }
        }
    }

    static void AddOrder(Menu menu, List<Customer> customers)
    {
        Console.Write("Enter customer name: ");
        string customerName = Console.ReadLine();

        var customer = customers.FirstOrDefault(c => c.Name == customerName);
        if (customer == null)
        {
            customer = new Customer(customerName);
            customers.Add(customer);
        }

        var order = new Order();
        Console.WriteLine("Add items to the order (enter 'done' to finish):");

        while (true)
        {
            Console.Write("Enter item name: ");
            string itemName = Console.ReadLine();
            if (itemName.Equals("done", StringComparison.OrdinalIgnoreCase)) break;

            IOrderable item = menu.Dishes.FirstOrDefault(d => d.Name == itemName);

            if (item == null)
            {
                item = menu.Drinks.FirstOrDefault(d => d.Name == itemName);
            }

            if (item != null)
            {
                order.AddItem(item);
                Console.WriteLine($"{item.Name} added to the order.");
            }
            else
            {
                Console.WriteLine("Item not found in the menu.");
            }
        }

        customer.PlaceOrder(order);
        Console.WriteLine("Order created successfully.");
    }


    static void AssignOrderToWaiter(List<Customer> customers, List<Waiter> waiters)
    {
        Console.Write("Enter customer name: ");
        string customerName = Console.ReadLine();

        var customer = customers.FirstOrDefault(c => c.Name == customerName);
        if (customer == null || customer.Orders.Count == 0)
        {
            Console.WriteLine("No orders found for this customer.");
            return;
        }

        Console.Write("Enter order index to assign (1 to N): ");
        if (int.TryParse(Console.ReadLine(), out int orderIndex) && orderIndex >= 1 && orderIndex <= customer.Orders.Count)
        {
            var order = customer.Orders[orderIndex - 1];

            Console.WriteLine("Available waiters:");
            for (int i = 0; i < waiters.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {waiters[i].Name}");
            }

            Console.Write("Choose a waiter by index: ");
            if (int.TryParse(Console.ReadLine(), out int waiterIndex) && waiterIndex >= 1 && waiterIndex <= waiters.Count)
            {
                var waiter = waiters[waiterIndex - 1];
                waiter.TakeOrder(order);
            }
            else
            {
                Console.WriteLine("Invalid waiter index.");
            }
        }
        else
        {
            Console.WriteLine("Invalid order index.");
        }
    }

    static void ServeOrderByWaiter(List<Waiter> waiters)
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
            waiter.PrintActiveOrders();

            Console.Write("Enter order index to serve (1 to N): ");
            if (int.TryParse(Console.ReadLine(), out int orderIndex) && orderIndex >= 1 && orderIndex <= waiter.ActiveOrders.Count)
            {
                var order = waiter.ActiveOrders[orderIndex - 1];
                waiter.ServeOrder(order);
                Console.WriteLine("Order has been served.");
            }
            else
            {
                Console.WriteLine("Invalid order index.");
            }
        }
        else
        {
            Console.WriteLine("Invalid waiter index.");
        }
    }
}