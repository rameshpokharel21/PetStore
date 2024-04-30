using ProductCollection.Extension;
using ProductCollection.Helper;
using ProductCollection.ProductModel;

namespace ProductCollection.ProductListCreators;

public class ProductListByName
{
    public static void PrintProductByName(IProductLogic logic)
    {
        Console.WriteLine("\nEnter product name:");
        string? name = Console.ReadLine()?.ToLower() ?? "no name";
        Product food = logic.GetCatFoodByName(name);
        Product leash = logic.GetDogLeashByName(name);

        if (food is not null)
        {
            decimal discountedPriceStatic = FormatHelper.RoundToTwo(DecimalExtensions.DiscountPrice(food.Price));
            decimal discountedPriceExtension = FormatHelper.RoundToTwo(food.Price.DiscountThisPrice());
            PrintHelper.PrintItem(food, "Cat Food Product");
            PrintHelper.PrintItem(discountedPriceStatic, "Discounted Price");
            PrintHelper.PrintItem(discountedPriceExtension, "Discounted Price");

        }
        else if (leash is not null)
        {
            decimal discountedPriceStatic = FormatHelper.RoundToTwo(DecimalExtensions.DiscountPrice(leash.Price));
            decimal discountedPriceExtension = FormatHelper.RoundToTwo(leash.Price.DiscountThisPrice());
            PrintHelper.PrintItem(leash, "Dog Leash Product");
            PrintHelper.PrintItem(discountedPriceStatic, "Discounted Price");
            PrintHelper.PrintItem(discountedPriceExtension, "Discounted Price");
        }
        else
        {
            Console.WriteLine($"The name is not in the list: {name}");
        }
    }
}