using ProductCollection.ProductModel;
using ProductCollection.UI;

namespace ProductCollection.Logic;

public class ProductAdder
{

    public static void AddProductToList(IProductLogic productLogic)
    {
        try
        {
            Product product = UserEntry.GetProductFromUser();
            if (product is DogLeash)
            {
                productLogic.AddProduct((DogLeash)product);
                Console.WriteLine("\nThe DogLeash product was added to the List\n");
            }
            else if (product is CatFood)
            {
                productLogic.AddProduct((CatFood)product);
                Console.WriteLine("\nThe CatFood product was added to the List\n");
            }
            else
            {
                throw new ArgumentException("\nProcut is null or product Logic IS null");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }



}