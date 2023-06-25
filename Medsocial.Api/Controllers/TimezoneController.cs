using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Medsocial.Solution.Controllers;

[ApiController]
[Route("api/timezones")]
public class TimezoneController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public TimezoneController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet("")]
    public async Task<ActionResult> GetTimezonesAsync()
    {
        var timezones = await _serviceManager.TimezoneService.GetTimezoneAsync(false);
        return Ok(timezones);
    }
}
