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
        Console.WriteLine("\nEnter product id:");
       while(!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Wrong type! Enter product id:");
        }
    
        Product product = logic.GetProductById(id);

        if (product is not null)
        {
            
            PrintHelper.PrintItem(product, "Product");
           
        }
        else
        {
            Console.WriteLine($"Product with {id} is not found in the list!");
        }
        
        
    }
}