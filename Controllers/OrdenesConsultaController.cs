using Lab08_RQuispe.Services.interfaces;
using Lab08_RQuispe.Services.Interfaces;
using Lab08_RQuispe.Services.Productos;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_RQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdenesConsultaController(

    IOrdenDetalleConsultaService _ordenDetalleConsultaService,
    IOrdenCantidadTotalService _ordenCantidadTotalService,
    IProductoFiltroService _productoFiltroService,
    IProductoMasCaroService _productoMasCaroService,
    IPedidosPorFechaService _pedidosPorFechaService,
    IPedidosConDetallesService _pedidosConDetallesService
) : ControllerBase

{


    [HttpGet("detalle-productos")]
    public async Task<IActionResult> ObtenerProductosPorOrden([FromQuery] int orderId)
    {
        var resultado = await _ordenDetalleConsultaService.ObtenerDetallePorOrdenAsync(orderId);
        return Ok(resultado);
    }

    [HttpGet("total-productos")]
    public async Task<IActionResult> ObtenerCantidadTotalProductos([FromQuery] int orderId)
    {
        var total = await _ordenCantidadTotalService.ObtenerCantidadTotalPorOrdenAsync(orderId);
        return Ok(new { OrderId = orderId, CantidadTotal = total });
    }

    [HttpGet("mas-caro")]
    public async Task<IActionResult> ObtenerProductoMasCaro()
    {
        var resultado = await _productoMasCaroService.ObtenerProductoMasCaroAsync();
        return Ok(resultado);
    }

    [HttpGet("posteriores-a")]
    public async Task<IActionResult> ObtenerPedidosPosterioresA([FromQuery] DateTime fecha)
    {
        var resultado = await _pedidosPorFechaService.ObtenerPedidosDespuesDeFechaAsync(fecha);
        return Ok(resultado);
    }

    [HttpGet("todos-detalles")]
    public async Task<IActionResult> ObtenerTodosLosDetalles()
    {
        var resultado = await _pedidosConDetallesService.ObtenerPedidosConDetallesAsync();
        return Ok(resultado);
    }
    

}