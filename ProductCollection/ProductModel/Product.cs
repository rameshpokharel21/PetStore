/*
 * This is a base class with 4 Properties with both readable and writable accessors
 */

namespace ProductCollection.ProductModel;


public class Product(string name, decimal price, int quantity, string description)
{

    public string Name { get; private set; } = name.ToLower();

    public decimal Price { get; private set; } = price;
    public int Quantity { get; private set; } = quantity;
    public string Description { get; private set; } = description;
    public override string ToString() => $"Name: {Name}\nPrice: {Price:C2}\nQuantity: {Quantity}\nDescription: {Description}";
}
