﻿using ProductCollection;
using System.Text;
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

PrintMessages();

string? userInput = Console.ReadLine() ?? "0";

while (!userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))

{
    int convertedInput = 0;
    string? name;
    decimal price = 0.00M;
    int quantity = 0;
    string? description;

    int.TryParse(userInput, out convertedInput);

    //if convetedInput is not 1, 2, or "exit" ask user to reenter
    
    while (convertedInput != 1 && convertedInput != 2)
    {
        Console.WriteLine($"\nWrong input: {userInput}");
        PrintMessages();
        userInput = Console.ReadLine() ?? "0";
        int.TryParse(userInput, out convertedInput);
        if(userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Bye bye!");
            System.Environment.Exit(0);
        }
    }
    
    
    /*
    First get user inputs for parent class Properties
    which is inherited to all derived classes
    For null name it takes "no name".
    when user enters 1:
    enforces user to input right data type
    */


    if (convertedInput == 1)
    {
        Console.WriteLine("\nType catfood or dogleash to add them:");
        string? typeName = Console.ReadLine() ?? "none";

        //repeatedly asks user to enter dogleash or catfood as one word if the input is different 
        while (!typeName.Equals("dogleash", StringComparison.OrdinalIgnoreCase) && !typeName.Equals("catfood", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Wrong prduct type: {typeName}.");

            Console.WriteLine("\nType catfood or dogleash to add them:");
            typeName = Console.ReadLine() ?? "none";

            
        }

        //enforces unique product name
        do
        {
            Console.WriteLine("\nEnter unique name for the product:");
            name = Console.ReadLine().ToLower() ?? "no name";
        }
        while (productLogic.GetCatFoodByName(name) != null || productLogic.GetDogLeashByName(name) != null);

        Console.WriteLine($"The received value is {name}");

        do
        {
        
            Console.WriteLine("\nEnter price for the product:");
            
        }
        while (!decimal.TryParse(Console.ReadLine(), out price));

        Console.WriteLine($"The received value is {price}");


        do
        {
            Console.WriteLine("\nEnter quantity as a whole number:");
        }
        while (!int.TryParse(Console.ReadLine(), out quantity));

        Console.WriteLine($"The received value is {quantity}");

        Console.WriteLine("\nEnter description for the product:");
        description = Console.ReadLine() ?? "no description";
        Console.WriteLine($"The received value is {description}");

        /*
         CatFood class Properties input from user
        and initializing and displaying CatFood object
        User is not allowed to enter other types for double
        and bool.
        */
        if (typeName.Equals("catfood", StringComparison.OrdinalIgnoreCase))
        {
            double weightPounds = 0;
            bool kittenFood = false;
            do
            {
                Console.WriteLine("\nEnter weight in pounds for cat food:");
            }
            while (!double.TryParse(Console.ReadLine(), out weightPounds));

            Console.WriteLine($"The received value is {weightPounds}");

            do
            {
                Console.WriteLine("\nIs it kitten food(true or false)");
            }
            while (!bool.TryParse(Console.ReadLine(), out kittenFood));
            Console.WriteLine($"The received value is {kittenFood}");

            //creating CatFood object with given Properties
            catFood = new CatFood(name, price, quantity, description, weightPounds, kittenFood);


            productLogic.AddProduct((CatFood)catFood);

            Console.WriteLine("\nThe CatFood product was added to the productLogic List\n");

        }

        /*
         DogLeash class Properties entries from user
        and initializing and displaying DogLeash object
        if user is not allowed to enter differt data type
        for int type.
        if string is null, it takes 'no material type' for Material Property
        */
        if (typeName.Equals("dogleash", StringComparison.OrdinalIgnoreCase))
        {
            int lengthInches = 0;
            string? material;
            do
            {
                Console.WriteLine("\nEnter leash length in inches(whole number):");
            }
            while (!int.TryParse(Console.ReadLine(), out lengthInches));
            
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

    //when user enters 2
    if (convertedInput == 2)
    {

        Console.WriteLine("\nEnter product name:");

        string? productName = Console.ReadLine().ToLower() ?? "no name";


        Product food = productLogic.GetCatFoodByName(productName);
        Product leash = productLogic.GetDogLeashByName(productName);


        if (food is not null)
        {
            Console.WriteLine("\nHere is the cat food product:\n");
            Console.WriteLine(food.ToString());
        }

        else if (leash is not null)
        {     
            Console.WriteLine("\nHere is the dog leash product:\n");
            Console.WriteLine(leash.ToString());

        }
        else
        {
            Console.WriteLine($"The name is not in the list: {productName}");
        }




    }

    PrintMessages();
    userInput = Console.ReadLine() ?? "0";

}

Console.WriteLine("\nBye bye!\n");


//showing instructions for user
static void PrintMessages()
{
    Console.WriteLine("\nPress 1 to add a Product.");
    Console.WriteLine("Press 2 to print a product by name.");
    Console.WriteLine("Type 'exit' to quit.");
}