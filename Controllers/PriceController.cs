using dotnet.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class PriceController : ControllerBase
{
    private readonly ILogger<PriceController> _logger;

    public PriceController(ILogger<PriceController> logger)
    {
        _logger = logger;
    }

    [HttpPost("price")]
    public Price Get([FromBody] Price price)
    {
        _logger.LogInformation("Received valid request.");
        return PriceHelper.CalculateMissing(price);
    }
}
