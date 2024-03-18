using ProductCollection;
using System.Text.Json;

/*
Asks for user input of 1, 2 or 'exit'.
Repeats the process as long as user doesn't type 'exit'
if user enters other number or other letters or null
default value will be 0.
*/

Console.WriteLine("\nPress 1 to enter Product type of CatFood.");
Console.WriteLine("Press 2 to enter Product type of DogLeash.");
Console.WriteLine("Type 'exit' to quit.");

string? userInput = Console.ReadLine() ?? "0";

while (userInput != "exit")
{
    int convertedInput;
    string? name;
    decimal price;
    int quantity;
    string? description;

    int.TryParse(userInput, out convertedInput);

    //if convetedInput is not 1 or 2, throw an exception
    if (convertedInput != 1 && convertedInput != 2)
    {
        
        throw new ArgumentOutOfRangeException($"Wrong entry: {userInput}");
    }

    /*
    First get user inputs for parent class Properties
    which is inherited to all derived classes
    For null name it takes "no name".
    if user enters letter for numerical value, it takes 0
    It takes 0 if user enters other than integer type for Quantity Property
    */

    Console.WriteLine("\nEnter name of the product:");
    name = Console.ReadLine() ?? "no name";
    Console.WriteLine($"The received value is {name}");

    Console.WriteLine("\nEnter price for the product:");  
    decimal.TryParse(Console.ReadLine(), out price);
    Console.WriteLine($"The received value is {price}");

    Console.WriteLine("\nEnter quantity as a whole number:");
    int.TryParse(Console.ReadLine(), out quantity);
    Console.WriteLine($"The received value is {quantity}");

    Console.WriteLine("\nEnter description for the product:");
    description = Console.ReadLine() ?? "no description";
    Console.WriteLine($"The received value is {description}");

    /*
     CatFood class Properties input from user
    and initializing and displaying CatFood object
    if user enters non-numerial value for double, it takes 0
    if user enters other than bool for bool type, it takes false
    */
    if (convertedInput == 1)
    {
        double weightPounds;
        bool kittenFood;

        Console.WriteLine("\nEnter weight in pounds for cat food:");
        double.TryParse(Console.ReadLine(), out weightPounds);
        Console.WriteLine($"The received value is {weightPounds}");

        Console.WriteLine("\nIs it kitten food(true or false)");
        bool.TryParse(Console.ReadLine(), out kittenFood);
        Console.WriteLine($"The received value is {kittenFood}");

        //creating CatFood object with given Properties
        Product catFood = new CatFood(name, price, quantity, description, weightPounds, kittenFood);

        Console.WriteLine("\nHere is the cat food object: ");
        Console.WriteLine(JsonSerializer.Serialize<CatFood>((CatFood)catFood));


    }

    /*
     DogLeash class Properties entries from user
    and initializing and displaying DogLeash object
    it truncates other numerical value to int for LengthInches Property
    if user enter other than int type for LengthInches, it takes 0
    if string is null, it takes 'no material type' for Material Property
    */
    if (convertedInput == 2)
    {
        int lengthInches;
        string material;

        Console.WriteLine("\nEnter leash length in inches(whole number):");
        int.TryParse(Console.ReadLine(), out lengthInches);
        Console.WriteLine($"The received value is {lengthInches}");

        Console.WriteLine("\nEnter material for the leash:");
        material = Console.ReadLine() ?? "no material type";
        Console.WriteLine($"The received value is {material}");

        //create object with the values provided
        Product dogLeash = new DogLeash(name, price, quantity, description, lengthInches, material);

        Console.WriteLine("\nHere is the product:");
        Console.WriteLine(JsonSerializer.Serialize<DogLeash>((DogLeash)dogLeash));
    }

    Console.WriteLine("\nPress 1 to enter Product type of CatFood.");
    Console.WriteLine("Press 2 to enter Product type of DogLeash.");
    Console.WriteLine("Type 'exit' to quit.");

    userInput = Console.ReadLine() ?? "0";
   
}
Console.WriteLine("\nBye bye!\n");





