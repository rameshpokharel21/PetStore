namespace ProductCollection;

public class UserOptionFactory
{
    public void Create(ProductLogic logic){
    
        PrintHelper.PrintInstructions();
        string? userInput = Console.ReadLine() ?? "0";

        while (!userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))

        {
            int convertedInput = 0;
            int.TryParse(userInput, out convertedInput);

            /*
            First get user inputs for parent class Properties
            which is inherited to all derived classes
            */

            switch (convertedInput)
            {
                case 1:
                    ProductAdder.AddProductToList(logic);
                    break;

                case 2:
                    ProductListByName.PrintProductByName(logic);
                    break;

                case 8:
                    ProductAllList.PrintAllProductsList(logic);
                    break;

                case 9:
                    ProductInStockList.PrintInStockProductNamesList(logic);
                    break;

                case 10:
                    ProductOutOfStockList.PrintLOutOfProductsList(logic);
                    break;

                default:
                    Console.WriteLine($"\nWrong input: {userInput}");
                    break;
            }

            PrintHelper.PrintInstructions();
            userInput = Console.ReadLine() ?? "0";

        }

        PrintHelper.PrintGoodByeMessage();
    }
}