

using PetStore.Data;
using ProductCollection.Logic;

namespace PetStore.ProductQueryResults;

public class DeleteProductByProvidedId
{
    public static void deleteAProductById(IProductLogic logic)
    {
        int id;
        Console.WriteLine("\nEnter product id:");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Wrong type! Enter product id:");
        }
        if(logic.GetProductById(id) != null)
        {
            logic.DeleteAProductById(id);
        }
        else
        {
            Console.WriteLine($"Product with {id} is not found in the list!");
        }
    }
}
