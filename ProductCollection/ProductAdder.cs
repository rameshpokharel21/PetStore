
namespace ProductCollection;

public class ProductAdder
{

    public static void AddProductToList( ProductLogic productLogic)
    {
        string typeName = ProductEntryPrompts.GetProductType();
        string name = ProductEntryPrompts.GetProductName(productLogic);
        decimal price = ProductEntryPrompts.GetProductPrice();
        int quantity = ProductEntryPrompts.GetProductQuantity();
        string description = ProductEntryPrompts.GetProductDescription();

        if (typeName.Equals("catfood", StringComparison.OrdinalIgnoreCase))
        {
            double weightPounds = ProductEntryPrompts.GetCatFoodWeightInPounds();
            bool kittenFood = ProductEntryPrompts.IsCatFood();
            Product product = new CatFood(name, price, quantity, description, weightPounds, kittenFood);
            productLogic.AddProduct((CatFood)product);
            Console.WriteLine("\nThe CatFood product was added to the productLogic List\n");

        }

        else if (typeName.Equals("dogleash", StringComparison.OrdinalIgnoreCase))
        {
            int lengthInches = ProductEntryPrompts.GetLeashLengthInInches();
            string? material = ProductEntryPrompts.GetLeashMaterialType();
            Product product = new DogLeash(name, price, quantity, description, lengthInches, material);
            productLogic.AddProduct((DogLeash)product);
            Console.WriteLine("\nThe DogLeash product was added to the productLogic List\n");
        }
    }


}