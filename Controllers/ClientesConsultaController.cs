using Lab08_RQuispe.Services.interfaces;
using Lab08_RQuispe.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_RQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesConsultaController(
    IClienteBusquedaService _clienteBusquedaService,
    IClienteMayorPedidosService _clienteMayorPedidosService,
    IProductosPorClienteService _productosPorClienteService
    
    ) : ControllerBase
{
    
    [HttpGet("por-nombre")]
    public async Task<IActionResult> BuscarPorNombre([FromQuery] string nombre)
    {
        var resultado = await _clienteBusquedaService.BuscarClientesPorNombreAsync(nombre);
        return Ok(resultado);
    }
    
    [HttpGet("mayor-pedidos")]
    public async Task<IActionResult> ObtenerClienteConMasPedidos()
    {
        var resultado = await _clienteMayorPedidosService.ObtenerClienteConMasPedidosAsync();
        return Ok(resultado);
    }
    
    [HttpGet("productos-vendidos")]
    public async Task<IActionResult> ObtenerProductosVendidos([FromQuery] int clientId)
    {
        var resultado = await _productosPorClienteService.ObtenerProductosVendidosPorClienteAsync(clientId);
        return Ok(resultado);
    }


}