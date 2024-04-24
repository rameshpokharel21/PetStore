using ProductCollection;


/*

Repeats the process as long as user doesn't type 'exit'
Enforces user to enter right type using loop.
product name string will be converted to lower case
for using as a key (or id) for the product.
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
    */

    switch (convertedInput)
    {
        case 1:
           
            string typeName = GetProductType();
            name = GetProductName(productLogic);
            price = GetProductPrice();
            quantity = GetProductQuantity();
            description = GetProductDescription();

            if (typeName.Equals("catfood", StringComparison.OrdinalIgnoreCase))
            {
               double weightPounds = GetCatFoodWeightInPounds();
               bool kittenFood = IsCatFood();
               catFood = new CatFood(name, price, quantity, description, weightPounds, kittenFood);
               productLogic.AddProduct((CatFood)catFood);
               Console.WriteLine("\nThe CatFood product was added to the productLogic List\n");        

            }
           
            else if (typeName.Equals("dogleash", StringComparison.OrdinalIgnoreCase))
            {
                int lengthInches = GetLeashLengthInInches();
                string? material = GetLeashMaterialType();        
                dogLeash = new DogLeash(name, price, quantity, description, lengthInches, material);
                productLogic.AddProduct((DogLeash)dogLeash);
                Console.WriteLine("\nThe DogLeash product was added to the productLogic List\n");
            }
            break;

        case 2:
            Console.WriteLine("\nEnter product name:");
            string? productName = Console.ReadLine()?.ToLower() ?? "no name";
            PrintProductByName(productLogic, productName);           
            break;

        case 8:
            PrintAllProductsList(productLogic);
            break;

        case 9:
            PrintInStockProductNamesList(productLogic);
            break;

        case 10:
            PrintLOutOfProductsList(productLogic);
            break;

        default:
            Console.WriteLine($"\nWrong input: {userInput}");
            break;
    }

    PrintMessages();
    userInput = Console.ReadLine() ?? "0";

}

Console.WriteLine(@"
    Thank you for visiting Pet Store.
    Bye bye!
        ");


static void PrintMessages()
{
    Console.WriteLine(
        """

        Press 1 to add a Product.
        Press 2 to describe a product by name.
        Press 8 to list all products.
        Press 9 to list instock products.
        Press 10 to list out-of-stock products.
        Type 'exit' to quit.

        """
        );
}

static string GetProductName(ProductLogic logic)
{
    string? productName;
    do
    {
        Console.WriteLine("\nEnter unique name for the product:");
        productName = Console.ReadLine()?.ToLower() ?? "no name";
    }
    while (logic.GetCatFoodByName(productName) != null || logic.GetDogLeashByName(productName) != null);
    return productName;
}

static decimal GetProductPrice()
{
    decimal productPrice;

    do
    {

        Console.WriteLine("\nEnter price for the product:");

    }
    while (!decimal.TryParse(Console.ReadLine(), out productPrice));

    return productPrice;
}

static int GetProductQuantity()
{
    int productQuantity;
    do
    {
        Console.WriteLine("\nEnter quantity as a whole number:");
    }
    while (!int.TryParse(Console.ReadLine(), out productQuantity));

    return productQuantity;
}

static string GetProductDescription()
{
    Console.WriteLine("\nEnter description for the product:");
    string? productDescription = Console.ReadLine() ?? "no description";
    return productDescription;
}

static string GetProductType()
{
    Console.WriteLine("\nType catfood or dogleash to add them:");
    string? productType = Console.ReadLine() ?? "none";


    while (!productType.Equals("dogleash", StringComparison.OrdinalIgnoreCase) && !productType.Equals("catfood", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine($"Wrong prduct type: {productType}.");

        Console.WriteLine("\nType catfood or dogleash to add them:");
        productType = Console.ReadLine() ?? "none";
    }
    return productType;
}

static double GetCatFoodWeightInPounds()
{
    double catFoodWeightInPounds;
    do
    {
        Console.WriteLine("\nEnter weight in pounds for cat food:");
    }
    while (!double.TryParse(Console.ReadLine(), out catFoodWeightInPounds));

    return catFoodWeightInPounds;
}

static bool IsCatFood()
{
    bool isCatFood;
    do
    {
        Console.WriteLine("\nIs it kitten food(true or false)");
    }
    while (!bool.TryParse(Console.ReadLine(), out isCatFood));

    return isCatFood;
}

static int GetLeashLengthInInches()
{
    int leashLengthInInches;
    do
    {
        Console.WriteLine("\nEnter leash length in inches(whole number):");
    }
    while (!int.TryParse(Console.ReadLine(), out leashLengthInInches));

    return leashLengthInInches;
}

static string GetLeashMaterialType()
{
    Console.WriteLine("\nEnter material for the leash:");
    string materialType = Console.ReadLine() ?? "no material type";
    return materialType;
}
static void PrintProductByName(ProductLogic logic, string name)
{
    Product food = logic.GetCatFoodByName(name);
    Product leash = logic.GetDogLeashByName(name);

    if (food is not null)
    {
        decimal discountedPriceStatic = Math.Round(DecimalExtensions.DiscountPrice(food.Price), 2);
        decimal discountedPriceExtension = Math.Round(DecimalExtensions.DiscountThisPrice(food.Price), 2);
        Console.WriteLine(
            $"""

                    Here is the cat food product:
                    -------------------------
                    {food.ToString()}
                    Discounted Price: {discountedPriceStatic};
                    Discounted Price: {discountedPriceExtension};
                    -------------------------
                    """
            );
    }
    else if (leash is not null)
    {
        decimal discountedPriceStatic = Math.Round(DecimalExtensions.DiscountPrice(leash.Price), 2);
        decimal discountedPriceExtension = Math.Round(DecimalExtensions.DiscountThisPrice(leash.Price), 2);
        Console.WriteLine(
           $"""

                    Here is the dog leash product:
                    -------------------------
                    {leash.ToString()}
                    Discounted Price: {discountedPriceStatic};
                    Discounted Price: {discountedPriceExtension};
                    -------------------------
                    """
           );
    }
    else
    {
        Console.WriteLine($"The name is not in the list: {name}");
    }
}

static void PrintLOutOfProductsList(ProductLogic productLogic)
{
    List<Product> outOfStockProducts = productLogic.GetOutOfStockProducts();
    if (outOfStockProducts?.Count > 0)
    {
        int outOfstockCounter = 0;
        Console.WriteLine("\nOut-of-stock products:");
        Console.WriteLine("-------------------------");
        foreach (var product in outOfStockProducts)
        {
            Console.WriteLine($"{++outOfstockCounter}. {product}\n");
        }
        Console.WriteLine("-------------------------");
    }
    else
    {
        Console.WriteLine("There isn't any out-of-stock product now.");
    }
    Console.WriteLine();
}

static void PrintInStockProductNamesList(ProductLogic productLogic)
{
    List<string> inStockProducts = productLogic.GetOnlyInStockProducts();
    if (inStockProducts?.Count > 0)
    {
        int instockCounter = 0;
        Console.WriteLine("\nin-stock product names:");
        Console.WriteLine("-------------------------");
        foreach (var inStockName in inStockProducts)
        {
            Console.WriteLine($"{++instockCounter}. {inStockName}\n");
        }
        Console.WriteLine("-------------------------");
    }
    else
    {
        Console.WriteLine("There isn't any instock product now.");
    }
    Console.WriteLine();
}

static void PrintAllProductsList(ProductLogic productLogic)
{
    List<Product> allProducts = productLogic.GetAllProducts();
    if (allProducts?.Count > 0)
    {
        int allProductCounter = 0;
        Console.WriteLine("\nAll products list:");
        Console.WriteLine("-------------------------");
        foreach (var product in allProducts)
        {
            Console.WriteLine($"{++allProductCounter}. {product}\n");
        }
        Console.WriteLine("-------------------------");
    }
    else
    {
        Console.WriteLine("There isn't any product now.");
    }
    Console.WriteLine();
}
