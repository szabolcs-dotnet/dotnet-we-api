using System.ComponentModel.DataAnnotations;

namespace dotnet.ControllersRequestValidators;

public class PriceRateValidationAttribute : ValidationAttribute
{
    private static readonly IList<decimal> ValidVATRates = new List<decimal> {
        0.2M,
        0.13M,
        0.1M
    };

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var price = (Price)validationContext.ObjectInstance;

        if (!ValidVATRates.Contains(price.Rate))
        {
            return new ValidationResult("VAT rate must be one of " + string.Join(", ", ValidVATRates.Select(rate => rate.ToString()).ToArray()) + "!");
        }


        return ValidationResult.Success;
    }
}