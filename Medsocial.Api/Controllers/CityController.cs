using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Medsocial.Solution.Controllers;

[ApiController]
[Route("api/cities")]
public class CityController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public CityController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet("by-country/{countryId}")]
    public async Task<ActionResult> GetCitiesByCountry(Guid countryId)
    {
        var cities = await _serviceManager.CityService.GetCitiesByCountryAsync(countryId, false);
        return Ok(cities);
    }
}