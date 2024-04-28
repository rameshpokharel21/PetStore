namespace ProductCollection;

public class ProductOutOfStockList
{
    public static void PrintLOutOfProductsList(ProductLogic productLogic)
    {
        List<Product> outOfStockProducts = productLogic.GetOutOfStockProducts();
        if (outOfStockProducts?.Count > 0)
        {      
            PrintHelper.PrintList(outOfStockProducts, "Out-of-stock products");         
        }
        else
        {
            Console.WriteLine("There isn't any out-of-stock product now.");
        }
        Console.WriteLine();
    }
}