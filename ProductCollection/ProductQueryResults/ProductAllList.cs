using ProductCollection.Helper;
using ProductCollection.Logic;
using PetStore.Data;


namespace ProductCollection.ProductListCreators;

public class ProductAllList
{
    public static void PrintAllProductsList(IProductLogic productLogic)
    {
        List<Product> allProducts = (List<Product>)productLogic.GetAllProducts();
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