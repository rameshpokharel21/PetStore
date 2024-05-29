using FluentValidation;
using ProductCollection.Helper;
using PetStore.Data;
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
                Console.WriteLine("\nEnter the product in Json format:");
                String? userInput = Console.ReadLine();

                Product? product = JsonSerializer.Deserialize<Product>(userInput);
                var validator = new ProductValidator();
                FluentValidation.Results.ValidationResult? productResults = validator.Validate(product);

                if (!productResults.IsValid)
                {
                    FormatHelper.PrintDottedLine();
                    foreach (var error in productResults.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                    FormatHelper.PrintDottedLine();
                }
                else
                {
                    return product;

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

}
