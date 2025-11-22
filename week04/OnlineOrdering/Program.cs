using System;
using System.Collections.Generic;

public class Product
{
    // Private member variables
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    // Constructor
    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Public method to compute the total cost for this specific product
    // Total cost = price * quantity
    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }

    // Getters for packing label
    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }
}


public class Address
{
    // Private member variables
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    // Constructor
    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    // Method to check if the address is in the USA (case-insensitive check)
    public bool IsInUSA()
    {
        return _country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    // Method to return the address as a formatted string
    public string GetFullAddressString()
    {
        // Use \n for newline characters
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
    }
}


public class Customer
{
    // Private member variables
    private string _name;
    private Address _address; 

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Method to check if the customer lives in the USA (delegates to Address class)
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    // Getters for shipping label
    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }
}


public class Order
{
    // Private member variables
    private List<Product> _products;
    private Customer _customer;

    // Constructor
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Method to add products to the list
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Method to calculate the total cost of the order (products + shipping)
    public decimal GetTotalCost()
    {
        decimal productsTotal = 0;
        
        // Sum the total cost of each product
        foreach (Product product in _products)
        {
            productsTotal += product.GetTotalCost();
        }

        
        decimal shippingCost = _customer.IsInUSA() ? 5m : 35m;

        
        return productsTotal + shippingCost;
    }

    
    public string GetPackingLabel()
    {
        string label = "--- Packing Label ---\n";
        foreach (Product product in _products)
        {
            label += $"Product: {product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    
    public string GetShippingLabel()
    {
        string label = "--- Shipping Label ---\n";
        label += $"Customer: {_customer.GetName()}\n";
        label += _customer.GetAddress().GetFullAddressString();
        return label;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("✨ Online Ordering System Demonstration ✨\n");

        // --- ORDER 1: USA Customer (Domestic) ---
        // Shipping cost: $5.00

        Console.WriteLine("------------------------------------------");
        Console.WriteLine("## ORDER 1: Domestic Shipping ($5.00)");
        Console.WriteLine("------------------------------------------");

        // Setup Customer 1 (USA)
        Address address1 = new Address("456 Oak Lane", "Salt Lake City", "UT", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);
        
        // Create Products for Order 1
        Product p1 = new Product("Wireless Mouse", "WM-100", 25.50m, 2); 
        Product p2 = new Product("Mechanical Keyboard", "MK-900", 79.99m, 1); 
        
        // Create Order 1 and add products
        Order order1 = new Order(customer1);
        order1.AddProduct(p1);
        order1.AddProduct(p2);

        // Display results for Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Order Cost: ${order1.GetTotalCost():F2}\n");


        Console.WriteLine("------------------------------------------");
        Console.WriteLine("## ORDER 2: International Shipping ($35.00)");
        Console.WriteLine("------------------------------------------");

        // Setup Customer 2 (Canada)
        Address address2 = new Address("10 King St W", "Toronto", "Ontario", "Canada");
        Customer customer2 = new Customer("Robert Smith", address2);
        
        // Create Products for Order 2
        Product p3 = new Product("USB-C Hub", "UH-C4", 19.99m, 3); 
        Product p4 = new Product("Laptop Stand", "LS-05", 35.00m, 1); 
        Product p5 = new Product("External SSD", "ES-2TB", 120.00m, 1); 
        
        // Create Order 2 and add products
        Order order2 = new Order(customer2);
        order2.AddProduct(p3);
        order2.AddProduct(p4);
        order2.AddProduct(p5);

        // Display results for Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        // Products Total: (19.99 * 3) + 35.00 + 120.00 = $219.97
        // Final Total: $219.97 + $35.00 = $254.97
        Console.WriteLine($"Total Order Cost: ${order2.GetTotalCost():F2}\n");
    }
}