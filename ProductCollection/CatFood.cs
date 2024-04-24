

namespace ProductCollection;

internal class CatFood(string name, decimal price, int quantity, string description, double weightPounds, bool kittenFood) : Product(name, price, quantity, description)
{
    public double WeightPounds { get; private set; } = weightPounds;
    public bool KittenFood { get; private set; } = kittenFood;
    public override string ToString() => $"{base.ToString()}\nWeight(pounds): {WeightPounds}\nIsKittenFood: {KittenFood}";
}
