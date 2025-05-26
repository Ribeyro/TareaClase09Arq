using Lab08_RQuispe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_RQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientOrdersController : ControllerBase
{
    private readonly IClientOrderService _service;

    public ClientOrdersController(IClientOrderService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _service.GetClientOrdersAsync();
        return Ok(result);
    }
}