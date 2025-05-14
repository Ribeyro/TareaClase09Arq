using Lab08_RQuispe.Data.UnitOfWork;
using Lab08_RQuispe.Services.interfaces;

namespace Lab08_RQuispe.Services.Implements;

public class OrdenCantidadTotalService : IOrdenCantidadTotalService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdenCantidadTotalService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> ObtenerCantidadTotalPorOrdenAsync(int orderId)
    {
        var detalles = await _unitOfWork.Orderdetails.FindAsync(od => od.OrderId == orderId);
        return detalles.Sum(d => d.Quantity);
    }
}