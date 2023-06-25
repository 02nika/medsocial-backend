using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Medsocial.Solution.Controllers;

[ApiController]
[Route("api/countries")]
public class CountryController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public CountryController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet("")]
    public async Task<ActionResult> GetCountriesAsync()
    {
        var countries = await _serviceManager.CountryService.GetCountriesAsync(false);
        return Ok(countries);
    }
}