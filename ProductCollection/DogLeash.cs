

namespace ProductCollection;

internal class DogLeash(string name, decimal price, int quantity, string description, int lengthInches, string material) : Product(name, price, quantity, description)
{
    public int LengthInches { get; private set; } = lengthInches;
    public string Material { get; private set; } = material;
    public override string ToString() => $"{base.ToString()}\nLeash length(inches): {LengthInches}\nMaterial Type: {Material}";
}

