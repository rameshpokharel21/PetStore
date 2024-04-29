namespace ProductCollection;

public class ProductAllList
{
    public static void PrintAllProductsList(ProductLogic productLogic)
    {
        List<Product> allProducts = productLogic.GetAllProducts();
        if (allProducts?.Count > 0)
        {
            PrintHelper.PrintList(allProducts, "All products list");
        }
        else
        {
            Console.WriteLine("There isn't any product now.");
        }
        Console.WriteLine();
    }
}