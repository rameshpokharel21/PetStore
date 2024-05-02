using ProductCollection.ProductModel;

namespace ProductCollection.UI;

public static class ProductEntryPrompts
{
    public static string GetProductName(IProductLogic logic)
    {
        string? productName;
        do
        {
            Console.WriteLine("\nEnter unique name for the product:");
            productName = Console.ReadLine()?.ToLower() ?? "no name";
        }
        while (logic.GetCatFoodByName(productName) != null || logic.GetDogLeashByName(productName) != null);
        return productName;
    }

    public static decimal GetProductPrice()
    {
        decimal productPrice;

        do
        {

            Console.WriteLine("\nEnter price for the product:");

        }
        while (!decimal.TryParse(Console.ReadLine(), out productPrice));

        return productPrice;
    }


    public static int GetProductQuantity()
    {
        int productQuantity;
        do
        {
            Console.WriteLine("\nEnter quantity as a whole number:");
        }
        while (!int.TryParse(Console.ReadLine(), out productQuantity));

        return productQuantity;
    }

    public static string GetProductDescription()
    {
        Console.WriteLine("\nEnter description for the product:");
        string? productDescription = Console.ReadLine() ?? "no description";
        return productDescription;
    }

    public static string GetProductType()
    {
        Console.WriteLine("\nType catfood or dogleash to add them:");
        string? productType = Console.ReadLine() ?? "none";


        while (!productType.Equals("dogleash", StringComparison.OrdinalIgnoreCase) && !productType.Equals("catfood", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Wrong prduct type: {productType}.");

            Console.WriteLine("\nType catfood or dogleash to add them:");
            productType = Console.ReadLine() ?? "none";
        }
        return productType;
    }

    public static double GetCatFoodWeightInPounds()
    {
        double catFoodWeightInPounds;
        do
        {
            Console.WriteLine("\nEnter weight in pounds for cat food:");
        }
        while (!double.TryParse(Console.ReadLine(), out catFoodWeightInPounds));

        return catFoodWeightInPounds;
    }

    public static bool IsCatFood()
    {
        bool isCatFood;
        do
        {
            Console.WriteLine("\nIs it kitten food(true or false)");
        }
        while (!bool.TryParse(Console.ReadLine(), out isCatFood));

        return isCatFood;
    }

    public static int GetLeashLengthInInches()
    {
        int leashLengthInInches;
        do
        {
            Console.WriteLine("\nEnter leash length in inches(whole number):");
        }
        while (!int.TryParse(Console.ReadLine(), out leashLengthInInches));

        return leashLengthInInches;
    }

    public static string GetLeashMaterialType()
    {
        Console.WriteLine("\nEnter material for the leash:");
        string materialType = Console.ReadLine() ?? "no material type";
        return materialType;
    }

}