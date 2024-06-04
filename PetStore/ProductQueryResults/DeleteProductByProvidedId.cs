

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

        try
        {
            Product product = logic.GetProductById(id);
            logic.DeleteAProductById(id);
            Console.WriteLine($"Product with id {id} deleted from database.");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}
