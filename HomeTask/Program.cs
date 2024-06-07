using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public class Product
{
    public string? Name { get; set; }
    public float Weight { get; set; }    
}

class Program
{
    
    static void Main()
    {
        var products = new List<Product>
        {
            new Product { Name = "Melon", Weight = 1.2f},
            new Product { Name = "Water melon", Weight= 0.8f},
            new Product { Name = "Ginger", Weight = 2.5f},
            new Product { Name = "Mango", Weight = 3.0f}
        };

        Func<Product, float> del = GetPrice;
        //Product maxPricedProduct = products.MaxBy(p => p.Sale);
        Product maxPricedProduct = products.GetMax(del);
        
        Console.WriteLine($"Product with max weight: {maxPricedProduct.Name} {maxPricedProduct.Weight} kg.");
                
        float GetPrice(Product p)
        {
            return p.Weight;
        };

    }
}
