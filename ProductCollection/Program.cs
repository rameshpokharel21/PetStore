using ProductCollection;
using System.Text.Json;

/*
Asks for user input of 1, 2 or 'exit'.
Repeats the process as long as user doesn't type 'exit'
if user enters other number or other letters or null
default value will be 0.
*/

ProductLogic productLogic = new ProductLogic();
Product? catFood;
Product? dogLeash;

Console.WriteLine("\nPress 1 to add a Product.");
Console.WriteLine("Press 2 to print a product by name.");
Console.WriteLine("Type 'exit' to quit.");

string? userInput = Console.ReadLine() ?? "0";

while (userInput.ToLower() != "exit")
{
    int convertedInput = 0;
    string? name;
    decimal price = 0.00M;
    int quantity = 0;   
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




    if (convertedInput == 1)
    {
        Console.WriteLine("\nType catfood or dogleash to add them:");
        string? typeName = Console.ReadLine() ?? "none";

        if (typeName.ToLower() != "dogleash" && typeName.ToLower() != "catfood")
        {
            throw new ArgumentException($"Wrong prduct type: {typeName}");
        }

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
        if (typeName.ToLower().Equals("catfood"))
        {
            double weightPounds = 0;
            bool kittenFood = false;

            Console.WriteLine("\nEnter weight in pounds for cat food:");
            double.TryParse(Console.ReadLine(), out weightPounds);
            Console.WriteLine($"The received value is {weightPounds}");

            Console.WriteLine("\nIs it kitten food(true or false)");
            bool.TryParse(Console.ReadLine(), out kittenFood);
            Console.WriteLine($"The received value is {kittenFood}");

            //creating CatFood object with given Properties
            catFood = new CatFood(name, price, quantity, description, weightPounds, kittenFood);

           
            productLogic.AddProduct((CatFood)catFood);

            Console.WriteLine("\nThe CatFood product was added to the productLogic List\n");

        }

        /*
         DogLeash class Properties entries from user
        and initializing and displaying DogLeash object
        if user enter other than int type for LengthInches, it takes 0
        if string is null, it takes 'no material type' for Material Property
        */
        if (typeName.ToLower().Equals("dogleash"))
        {
            int lengthInches = 0;
            string? material;

            Console.WriteLine("\nEnter leash length in inches(whole number):");
            int.TryParse(Console.ReadLine(), out lengthInches);
            Console.WriteLine($"The received value is {lengthInches}");

            Console.WriteLine("\nEnter material for the leash:");
            material = Console.ReadLine() ?? "no material type";
            Console.WriteLine($"The received value is {material}");

            //create object with the values provided
            dogLeash = new DogLeash(name, price, quantity, description, lengthInches, material);

            
            productLogic.AddProduct((DogLeash)dogLeash);

            Console.WriteLine("\nThe DogLeash product was added to the productLogic List\n");
        }
    }

    if (convertedInput == 2)
    {
        Console.WriteLine("\nPress 3 to enter catfood name or 4 to enter dogleash name to print the product:");
        
        if(int.TryParse(Console.ReadLine(), out int productType))
        {
            if (productType == 3)
            {
                Console.WriteLine("\nEnter cat-food name: ");
                string? catFoodName = Console.ReadLine() ?? "";
                Console.WriteLine("");
                Console.WriteLine(JsonSerializer.Serialize(productLogic.GetCatFoodByName(catFoodName.ToLower())));
            }
            else if(productType == 4)
            {
                Console.WriteLine("\nEnter dog-leash name: ");
                string? dogLeashName = Console.ReadLine() ?? "";
                Console.WriteLine();
                Console.WriteLine(JsonSerializer.Serialize(productLogic.GetDogLeashByName(dogLeashName.ToLower())));
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Wrong type {productType}");
            }

        }

        else
        {
            throw new ArgumentOutOfRangeException($"Wrong type {productType}");
        }
    }

    Console.WriteLine("\nPress 1 to add a Product.");
    Console.WriteLine("Press 2 to print a product by name.");
    Console.WriteLine("Type 'exit' to quit.");

    userInput = Console.ReadLine() ?? "0";

   
}
Console.WriteLine("\nBye bye!\n");





