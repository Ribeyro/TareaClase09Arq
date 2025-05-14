using Lab08_RQuispe.Data.UnitOfWork;
using Lab08_RQuispe.Services.interfaces;

namespace Lab08_RQuispe.Services.Implements;

public class OrdenDetalleConsultaService : IOrdenDetalleConsultaService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdenDetalleConsultaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<object>> ObtenerDetallePorOrdenAsync(int orderId)
    {
        var detalles = await _unitOfWork.Orderdetails.FindAsync(od => od.OrderId == orderId);
        var productos = await _unitOfWork.Products.GetAllAsync();

        var resultado = from d in detalles
            join p in productos on d.ProductId equals p.ProductId
            select new
            {
                Producto = p.Name,
                Cantidad = d.Quantity
            };

        return resultado.ToList();
    }
}