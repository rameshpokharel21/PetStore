using PetStore.Data;
using ProductCollection.Logic;
using ProductCollection.UI;

namespace PetStore.ProductQueryResults;

public class ProductAdder
{

    public static void AddProductToList(IProductLogic productLogic)
    {
        try
        {
            Product product = UserEntry.GetProductFromUser();
            productLogic.AddProduct(product);
            Console.WriteLine("The product is added to the database.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }



}