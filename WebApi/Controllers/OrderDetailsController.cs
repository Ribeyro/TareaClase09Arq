using Lab08_RQuispe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_RQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailsController : ControllerBase
{
    private readonly IOrderDetailsService _service;

    public OrderDetailsController(IOrderDetailsService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var orders = await _service.GetOrdersWithDetailsAsync();
        return Ok(orders);
    }
}