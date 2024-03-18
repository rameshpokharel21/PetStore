/*
 * This is a base class with 4 Properties with both readable and writable accessors
 */

namespace ProductCollection;


internal class Product(string name, decimal price, int quantity, string description)
{

    public string Name { get; set; } = name;

    public decimal Price { get; set; } = price;
    public int Quantity { get; set; } = quantity;
    public string Description { get; set; } = description;
}
