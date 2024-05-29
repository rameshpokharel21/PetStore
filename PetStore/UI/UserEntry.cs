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
        bool isProductValid = true;
        do
        {
            try
            {
                Console.WriteLine("\nEnter the product in Json format:");
                String? userInput = Console.ReadLine();
                ArgumentNullException.ThrowIfNull(userInput);
                Product? product = JsonSerializer.Deserialize<Product>(userInput);
                ArgumentNullException.ThrowIfNull(product);
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
                    isProductValid = false;
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
        } while (!isProductValid);
        return null;
    }

}
