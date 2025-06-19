using System;
using System.Collections.Generic;

class Product
{
    public string ProductId { get; }
    public string ProductName { get; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public Product(string productId, string productName, int quantity, double price)
    {
        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        Price = price;
    }

    public override string ToString()
    {
        return $"{ProductId} - {ProductName} | Qty: {Quantity} | ₹{Price}";
    }
}

class InventoryManager
{
    private static InventoryManager _instance;
    private Dictionary<string, Product> inventory = new();

    private InventoryManager() {}

    public static InventoryManager GetInstance()
    {
        return _instance ??= new InventoryManager();
    }

    public void AddProduct(Product product)
    {
        if (inventory.ContainsKey(product.ProductId))
        {
            Console.WriteLine("Product already exists.");
        }
        else
        {
            inventory[product.ProductId] = product;
            Console.WriteLine("Product added.");
        }
    }

    public void UpdateProduct(string productId, int? quantity, double? price)
    {
        if (inventory.TryGetValue(productId, out Product p))
        {
            if (quantity.HasValue) p.Quantity = quantity.Value;
            if (price.HasValue) p.Price = price.Value;
            Console.WriteLine("Product updated.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void DeleteProduct(string productId)
    {
        if (inventory.Remove(productId))
        {
            Console.WriteLine("Product deleted.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void DisplayProduct(string productId)
    {
        if (inventory.TryGetValue(productId, out Product p))
        {
            Console.WriteLine(p);
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
}

class Program
{
    static void Main()
    {
        var manager = InventoryManager.GetInstance();

        while (true)
        {
            Console.WriteLine("\n1. Add\n2. Update\n3. Delete\n4. Display\n5. Exit");
            Console.Write("Choose: ");
            if (!int.TryParse(Console.ReadLine(), out int choice)) continue;

            if (choice == 1)
            {
                Console.Write("Enter ID: ");
                string id = Console.ReadLine();
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Quantity: ");
                int qty = int.Parse(Console.ReadLine());
                Console.Write("Enter Price: ");
                double price = double.Parse(Console.ReadLine());
                manager.AddProduct(new Product(id, name, qty, price));
            }
            else if (choice == 2)
            {
                Console.Write("Enter ID to update: ");
                string id = Console.ReadLine();
                Console.Write("Enter new quantity (-1 to skip): ");
                int qty = int.Parse(Console.ReadLine());
                Console.Write("Enter new price (-1 to skip): ");
                double price = double.Parse(Console.ReadLine());
                manager.UpdateProduct(id, qty == -1 ? null : qty, price == -1 ? null : price);
            }
            else if (choice == 3)
            {
                Console.Write("Enter ID to delete: ");
                string id = Console.ReadLine();
                manager.DeleteProduct(id);
            }
            else if (choice == 4)
            {
                Console.Write("Enter ID to view: ");
                string id = Console.ReadLine();
                manager.DisplayProduct(id);
            }
            else if (choice == 5)
            {
                break;
            }
        }
    }
}
