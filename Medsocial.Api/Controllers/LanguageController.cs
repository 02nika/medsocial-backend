using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Medsocial.Solution.Controllers;

[ApiController]
[Route("api/languages")]
public class LanguageController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public LanguageController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet("")]
    public async Task<ActionResult> GetLanguagesAsync()
    {
        var languages = await _serviceManager.LanguageService.GetLanguagesAsync(false);
        return Ok(languages);
    }
}
