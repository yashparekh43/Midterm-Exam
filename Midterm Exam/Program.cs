using System;

public class InventoryItem
{
    // Properties
    public string Name { get; set; }
    public int ID { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }

    // Constructor
    public InventoryItem(string name, int id, double price, int stockQuantity)
    {
        Name = name;
        ID = id;
        Price = price;
        StockQuantity = stockQuantity;
    }

    // Methods

    // Update the price of the item
    public void ChangePrice(double newPrice)
    {
        Price = newPrice;
    }

    // Restock the item
    public void ReplenishStock(int additionalQuantity)
    {
        StockQuantity += additionalQuantity;
    }

    // Sell an item
    public bool Sell(int quantitySold)
    {
        if (StockQuantity >= quantitySold)
        {
            StockQuantity -= quantitySold;
            return true; // Indicate successful sale
        }
        else
        {
            Console.WriteLine("Error: Insufficient stock.");
            return false; // Indicate unsuccessful sale
        }
    }

    // Check if an item is in stock
    public bool IsAvailable()
    {
        return StockQuantity > 0;
    }

    // Print item details
    public void DisplayDetails()
    {
        Console.WriteLine($"Item Name: {Name}, Item ID: {ID}, Price: ${Price}, Quantity in Stock: {StockQuantity}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter item name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter item ID:");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter price:");
        double price = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter quantity in stock:");
        int stockQuantity = int.Parse(Console.ReadLine());

        InventoryItem item = new InventoryItem(name, id, price, stockQuantity);

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Display item details");
            Console.WriteLine("2. Sell item");
            Console.WriteLine("3. Replenish stock");
            Console.WriteLine("4. Check availability");
            Console.WriteLine("5. Update price");
            Console.WriteLine("6. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    item.DisplayDetails();
                    break;
                case "2":
                    Console.WriteLine("Enter quantity to sell:");
                    int quantitySold = int.Parse(Console.ReadLine());
                    bool success = item.Sell(quantitySold);
                    if (success)
                    {
                        Console.WriteLine("Item sold.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Enter additional quantity to restock:");
                    int additionalQuantity = int.Parse(Console.ReadLine());
                    item.ReplenishStock(additionalQuantity);
                    Console.WriteLine("Stock replenished.");
                    break;
                case "4":
                    Console.WriteLine($"{item.Name} is {(item.IsAvailable() ? "available" : "out of stock")}, Quantity in Stock: {item.StockQuantity}.");
                    break;
                case "5":
                    Console.WriteLine("Enter new price:");
                    double newPrice = double.Parse(Console.ReadLine());
                    item.ChangePrice(newPrice);
                    Console.WriteLine("Price updated.");
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }
}