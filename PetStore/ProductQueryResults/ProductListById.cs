using ProductCollection.Extension;
using ProductCollection.Helper;
using ProductCollection.Logic;
using PetStore.Data;

namespace ProductCollection.ProductListCreators;

public class ProductListById
{
    public static void PrintProductById(IProductLogic logic)
    {
        int id;
        Product? product = null;
        Console.WriteLine("\nEnter product id:");

       while(!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Wrong type! Enter product id:");
        }

        try
        {
            product = logic.GetProductById(id);
            PrintHelper.PrintItem(product, "Product");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine($"Product with ProductId {id} is not found in the list!");
        }

    }
}