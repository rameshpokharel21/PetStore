using FluentValidation;
using PetStore.Data;

namespace ProductCollection.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product).NotNull().NotEmpty().WithMessage("Product cannot be null or empty.");
        RuleFor(product => product.Name).NotNull().NotEmpty().WithMessage("Product Name cannot be null or empty.");
        RuleFor(product => product.Price).GreaterThan(0M).WithMessage("Product Price should be positive.");
        RuleFor(product => product.Quantity).GreaterThan(0).WithMessage("Product Quantity should be positive.");
        RuleFor(product => product.Description).MinimumLength(10).When(product => product.Description != null).WithMessage("Description if not null, should be at least 10 chars.");

    }
}

