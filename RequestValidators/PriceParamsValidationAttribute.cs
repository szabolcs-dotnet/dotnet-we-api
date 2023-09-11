using System.ComponentModel.DataAnnotations;

namespace dotnet.ControllersRequestValidators;

public class PriceParamsValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var price = (Price)validationContext.ObjectInstance;
        var priceParam = (decimal?)value;

        var priceParams = new List<decimal?> {
            price.Gross,
            price.Net,
            price.VAT
        };

        if (priceParams.Where(param => param != null).Count() > 1 && priceParam != null)
        {
            return new ValidationResult("Only one of either Net, Gross or VAT should be provided!");
        }

        if (priceParam <= 0)
        {
            return new ValidationResult("Value must be greater than 0!");
        }

        return ValidationResult.Success;
    }
}