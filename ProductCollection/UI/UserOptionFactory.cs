using System.Runtime.CompilerServices;
using ProductCollection.Helper;
using ProductCollection.Logic;
using ProductCollection.ProductListCreators;

namespace ProductCollection.UI;

public static class UserOptionFactory
{
    public static void Create(IProductLogic logic)
    {

        PrintHelper.PrintInstructions();

        string? userInput = Console.ReadLine() ?? "0";

        while (!userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))

        {
            int convertedInput = 0;
            int.TryParse(userInput, out convertedInput);

            switch (convertedInput)
            {
                case 1:
                    ProductAdder.AddProductToList(logic);
                    break;

                case 2:
                    ProductListById.PrintProductById(logic);
                    break;

                case 8:
                    ProductAllList.PrintAllProductsList(logic);
                    break;

                case 9:
                    
                    
                    break;

                default:
                    Console.WriteLine($"\nWrong input: {userInput}");
                    break;
            }

            PrintHelper.PrintInstructions();
            userInput = Console.ReadLine() ?? "0";

        }

    }
}