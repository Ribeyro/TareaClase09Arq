using Lab08_RQuispe.Services.interfaces;
using Lab08_RQuispe.Services.Interfaces;
using Lab08_RQuispe.Services.Productos;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_RQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosConsultaController(
    
        IProductoFiltroService _productoFiltroService,
        IPrecioPromedioProductoService _precioPromedioProductoService,
        IProductosSinDescripcionService _productosSinDescripcionService,
        IClientesPorProductoService _clientesPorProductoService
    ) : ControllerBase
{
    
        
    

    [HttpGet("mayor-a")]
    public async Task<IActionResult> ObtenerProductosMayoresA([FromQuery] decimal precio)
    {
        var resultado = await _productoFiltroService.ObtenerProductosConPrecioMayorAAsync(precio);
        return Ok(resultado);
    }
    
    [HttpGet("precio-promedio")]
    public async Task<IActionResult> ObtenerPrecioPromedio()
    {
        var promedio = await _precioPromedioProductoService.CalcularPromedioPrecioAsync();
        return Ok(new { PrecioPromedio = promedio });
    }
    
    [HttpGet("sin-descripcion")]
    public async Task<IActionResult> ObtenerProductosSinDescripcion()
    {
        var resultado = await _productosSinDescripcionService.ObtenerProductosSinDescripcionAsync();
        return Ok(resultado);
    }

    [HttpGet("clientes-por-producto")]
    public async Task<IActionResult> ObtenerClientesPorProducto([FromQuery] int productId)
    {
        var resultado = await _clientesPorProductoService.ObtenerClientesPorProductoAsync(productId);
        return Ok(resultado);
    }

}