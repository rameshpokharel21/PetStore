using FluentValidation;
using ProductCollection.Helper;
using ProductCollection.ProductModel;
using ProductCollection.Validators;
using System.Text.Json;

namespace ProductCollection.UI;

public  static class UserEntry
{
    public static Product GetProductFromUser()
    {
        bool isValid = false;
        do
        {
            try
            {
                string? type = GetProductType() ?? "none";
                Console.WriteLine("\nEnter the product in Json format:");
                String? userInput = Console.ReadLine();
                switch (type)
                {
                    case "dogleash":
                        DogLeash? leash = JsonSerializer.Deserialize<DogLeash>(userInput);
                        var validator = new DogLeashValidator();
                        FluentValidation.Results.ValidationResult? leashResults = validator.Validate(leash);
                        if (!leashResults.IsValid)
                        {
                            FormatHelper.PrintDottedLine();
                            foreach (var error in leashResults.Errors)
                            {
                                Console.WriteLine(error.ErrorMessage);
                            }
                            FormatHelper.PrintDottedLine();
                        }
                        else
                        {
                            return leash;
                        }
                        break;

                    case "catfood":
                        CatFood? food = JsonSerializer.Deserialize<CatFood>(userInput);
                        var foodValidator = new CatFoodValidator();
                        FluentValidation.Results.ValidationResult? foodResults = foodValidator.Validate(food);
                        if (!foodResults.IsValid)
                        {
                            FormatHelper.PrintDottedLine();
                            foreach (var error in foodResults.Errors)
                            {
                                Console.WriteLine(error.ErrorMessage);
                            }
                            FormatHelper.PrintDottedLine();
                        }
                        else
                        {
                            return food;
                        }
                        break;

                    default:
                        throw new ArgumentException("Invalid Product type.");

                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } while (!isValid);
        return null;
    }

    public static string GetProductType()
    {
        Console.WriteLine("\nType catfood or dogleash to add them:");
        string? productType = Console.ReadLine() ?? "none";


        while (!productType.Equals("dogleash", StringComparison.OrdinalIgnoreCase) && !productType.Equals("catfood", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Wrong prduct type: {productType}.");

            Console.WriteLine("\nType catfood or dogleash to add them:");
            productType = Console.ReadLine() ?? "none";
        }
        return productType.ToLower();
    }
   
 

}
