/*
 * DogLeash is child class of base class Product
 * It has two own Properties LengthInches of type int and Material of type string.
 * It inherits Name of type string, Price of type decimal, Quantity of type int and Description of type string from it's parent class Product.
 */

namespace ProductCollection;

internal class DogLeash(string name, decimal price, int quantity, string description, int lengthInches, string material) : Product(name, price, quantity, description)
{
    public int LengthInches { get; private set; } = lengthInches;
    public string Material { get; private set; } = material;
    public override string ToString() => $"{base.ToString()}\nLeash length(inches): {LengthInches}\nMaterial Type: {Material}";
}

