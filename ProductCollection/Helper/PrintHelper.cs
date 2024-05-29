namespace ProductCollection.Helper;
using System.Collections.Generic;

public static class PrintHelper
{
    public static void PrintInstructions()
    {
        Console.WriteLine(
            """

            Press 1 to add a Product.
            Press 2 to find a product by id.
            Press 8 to list all products.
            Press 9 to delete a product by id.
            Type 'exit' to quit.

            """
            );
    }
    public static void PrintList<T>(List<T> list, string heading)
    {
        int counter = 0;
        Console.WriteLine($"\n{heading}:");
        FormatHelper.PrintDottedLine();
        foreach (T item in list)
        {
            Console.WriteLine($"\n{++counter}. {item}");
        }
        FormatHelper.PrintDottedLine();
    }

    public static void PrintItem<T>(T? item, string heading)
    {
        Console.WriteLine($"\n{heading}:");
        FormatHelper.PrintDottedLine();
        Console.WriteLine($"{item?.ToString()}");
        FormatHelper.PrintDottedLine();
    }
}