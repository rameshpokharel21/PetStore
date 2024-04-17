using ProductCollection;

/*

Repeats the process as long as user doesn't type 'exit'
Enforces user to enter right type using loop.
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

    /*
    First get user inputs for parent class Properties
    which is inherited to all derived classes
    For null name it takes "no name".
    when user enters 1:
    enforces user to input right data type
    */


    switch (convertedInput)
    {
        case 1:

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
                name = Console.ReadLine()?.ToLower() ?? "no name";
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
            else if (typeName.Equals("dogleash", StringComparison.OrdinalIgnoreCase))
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
            break;

        case 2:


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
            break;

        case 3:

            List<string> inStockProducts = productLogic.GetOnlyInStockProducts();
            int counter = 0;
            Console.WriteLine("\nProduct names in stock:");
            foreach (var prod in inStockProducts)
            {
                Console.WriteLine($"{++counter}. {prod}");
            }
            Console.WriteLine();
            break;

        default:
            Console.WriteLine($"\nWrong input: {userInput}");
            break;
    }

    PrintMessages();
    userInput = Console.ReadLine() ?? "0";

}

Console.WriteLine("\nBye bye!\n");


//showing instructions for user
static void PrintMessages()
{
    Console.WriteLine("\nPress 1 to add a Product.");
    Console.WriteLine("Press 2 to describe a product by name.");
    Console.WriteLine("Press 3 to list instock products:");
    Console.WriteLine("Type 'exit' to quit.");
}

