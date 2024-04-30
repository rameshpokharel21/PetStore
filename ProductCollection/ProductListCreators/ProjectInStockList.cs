using ProductCollection.Helper;
using ProductCollection.ProductModel;

namespace ProductCollection.ProductListCreators;

public class ProductInStockList
{
    public static void PrintInStockProductNamesList(ProductLogic productLogic)
    {
        List<string> inStockProducts = productLogic.GetOnlyInStockProducts();
        if (inStockProducts.Count > 0)
        {
            PrintHelper.PrintList(inStockProducts, "In-stock product names:");

        }
        else
        {
            Console.WriteLine("There isn't any instock product now.");
        }
        Console.WriteLine();
    }
}