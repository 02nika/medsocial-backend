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
    
    [HttpGet]
    public async Task<ActionResult> GetAllCities()
    {
        var cities = await _serviceManager.CityService.GetCitiesAsync(false);
        return Ok(cities);
    }
}