using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IDbService _dbService;

    public ClientController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
}