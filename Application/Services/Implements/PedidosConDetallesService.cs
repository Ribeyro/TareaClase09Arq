using Lab08_RQuispe.Data.UnitOfWork;
using Lab08_RQuispe.Services.Interfaces;

namespace Lab08_RQuispe.Services.Implements;

public class PedidosConDetallesService : IPedidosConDetallesService
{
    private readonly IUnitOfWork _unitOfWork;

    public PedidosConDetallesService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<object>> ObtenerPedidosConDetallesAsync()
    {
        var detalles = await _unitOfWork.Orderdetails.GetAllAsync();
        var productos = await _unitOfWork.Products.GetAllAsync();
        var pedidos = await _unitOfWork.Orders.GetAllAsync();

        var resultado = from d in detalles
            join p in productos on d.ProductId equals p.ProductId
            join o in pedidos on d.OrderId equals o.OrderId
            group new { p.Name, d.Quantity } by o.OrderId into g
            select new
            {
                OrderId = g.Key,
                Detalles = g.Select(x => new
                {
                    Producto = x.Name,
                    Cantidad = x.Quantity
                })
            };

        return resultado.ToList();
    }
}