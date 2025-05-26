using Lab08_RQuispe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_RQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesByClientController : ControllerBase
{
    private readonly ISalesByClientService _service;

    public SalesByClientController(ISalesByClientService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _service.GetSalesByClientAsync();
        return Ok(result);
    }
}