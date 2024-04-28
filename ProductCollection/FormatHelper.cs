namespace ProductCollection;

public static class FormatHelper
{
    public static void PrintDottedLine(){
        Console.WriteLine("-------------------------");

    }

    public static decimal RoundToTwo(decimal number)
    {
        return Math.Round(number, 2);
    }
}