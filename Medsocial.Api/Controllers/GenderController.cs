using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Medsocial.Solution.Controllers;


[ApiController]
[Route("api/genders")]
public class GenderController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public GenderController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet("")]
    public async Task<ActionResult> GetGendersAsync()
    {
        var genders = await _serviceManager.GenderService.GetGendersAsync(false);
        return Ok(genders);
    }
}
