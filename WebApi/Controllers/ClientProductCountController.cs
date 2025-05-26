using Lab08_RQuispe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_RQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientProductCountController : ControllerBase
{
    private readonly IClientProductCountService _service;

    public ClientProductCountController(IClientProductCountService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _service.GetClientsWithProductCountAsync();
        return Ok(result);
    }
}
