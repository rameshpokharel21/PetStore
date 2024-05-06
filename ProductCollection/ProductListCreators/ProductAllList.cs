using ProductCollection.Helper;
using ProductCollection.Logic;
using ProductCollection.ProductModel;


namespace ProductCollection.ProductListCreators;

public class ProductAllList
{
    public static void PrintAllProductsList(IProductLogic productLogic)
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