using Lab08_RQuispe.Data.UnitOfWork;
using Lab08_RQuispe.Services.Interfaces;

namespace Lab08_RQuispe.Services.Implements;

public class ProductosPorClienteService : IProductosPorClienteService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductosPorClienteService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<object>> ObtenerProductosVendidosPorClienteAsync(int clientId)
    {
        var ordenes = await _unitOfWork.Orders.FindAsync(o => o.ClientId == clientId);
        var detalles = await _unitOfWork.Orderdetails.GetAllAsync();
        var productos = await _unitOfWork.Products.GetAllAsync();

        var resultado = from o in ordenes
            join d in detalles on o.OrderId equals d.OrderId
            join p in productos on d.ProductId equals p.ProductId
            select new
            {
                Producto = p.Name,
                Cantidad = d.Quantity
            };

        return resultado.ToList();
    }
}