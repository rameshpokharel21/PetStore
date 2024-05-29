using PetStore.Data;
using ProductCollection.UI;

namespace ProductCollection.Logic;

public class ProductAdder
{

    public static void AddProductToList(IProductLogic productLogic)
    {
        try
        {
            Product product = UserEntry.GetProductFromUser();
            productLogic.AddProduct(product);
           
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }



}