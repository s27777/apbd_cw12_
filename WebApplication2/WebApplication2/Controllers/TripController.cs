using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class TripController : ControllerBase
{
    private readonly IDbService _dbService;

    public TripController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrips()
    {
        try
        {
            var res = await _dbService.GetTrips();
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(500, "");
        }
    }
    
}