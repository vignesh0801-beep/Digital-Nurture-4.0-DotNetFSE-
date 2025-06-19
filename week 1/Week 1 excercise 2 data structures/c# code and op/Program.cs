using System;
using System.Collections.Generic;

class Product
{
    public int ProductId { get; }
    public string ProductName { get; }
    public string Category { get; }

    public Product(int productId, string productName, string category)
    {
        ProductId = productId;
        ProductName = productName;
        Category = category;
    }

    public override string ToString()
    {
        return $"{ProductId}: {ProductName} [{Category}]";
    }
}

interface ISearchStrategy
{
    Product Search(Product[] products, int productId);
}

class LinearSearch : ISearchStrategy
{
    public Product Search(Product[] products, int productId)
    {
        foreach (var p in products)
        {
            if (p.ProductId == productId)
                return p;
        }
        return null;
    }
}

class BinarySearch : ISearchStrategy
{
    public Product Search(Product[] products, int productId)
    {
        int l = 0, r = products.Length - 1;
        while (l <= r)
        {
            int m = (l + r) / 2;
            if (products[m].ProductId == productId)
                return products[m];
            if (products[m].ProductId < productId)
                l = m + 1;
            else
                r = m - 1;
        }
        return null;
    }
}

class SearchFactory
{
    public static ISearchStrategy Get(string type)
    {
        return type.ToLower() switch
        {
            "linear" => new LinearSearch(),
            "binary" => new BinarySearch(),
            _ => null,
        };
    }
}

class Program
{
    static void Main()
    {
        var productList = new List<Product>();
        Console.WriteLine("Enter product details (type 'stop' as ID to finish):");

        while (true)
        {
            Console.Write("Enter product ID: ");
            string idInput = Console.ReadLine();
            if (idInput.ToLower() == "stop")
                break;

            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("Invalid ID. Try again.");
                continue;
            }

            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter category: ");
            string category = Console.ReadLine();

            productList.Add(new Product(id, name, category));
        }

        Product[] products = productList.ToArray();

        Console.Write("Enter product ID to search: ");
        int idToSearch = int.Parse(Console.ReadLine());

        var linear = SearchFactory.Get("linear");
        var res1 = linear.Search(products, idToSearch);
        Console.WriteLine("Linear Search: " + (res1 != null ? res1.ToString() : "Not Found"));

        Array.Sort(products, (a, b) => a.ProductId.CompareTo(b.ProductId));

        var binary = SearchFactory.Get("binary");
        var res2 = binary.Search(products, idToSearch);
        Console.WriteLine("Binary Search: " + (res2 != null ? res2.ToString() : "Not Found"));
    }
}
