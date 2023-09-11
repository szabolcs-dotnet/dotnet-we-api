using System.ComponentModel.DataAnnotations;
using dotnet.ControllersRequestValidators;

namespace dotnet;

public class Price
{
    [PriceParamsValidation]
    public decimal? Net { get; set; }
    [PriceParamsValidation]
    public decimal? Gross { get; set; }
    [PriceParamsValidation]
    public decimal? VAT { get; set; }
    [Required]
    [PriceRateValidation]
    public decimal Rate { get; set; }
}
