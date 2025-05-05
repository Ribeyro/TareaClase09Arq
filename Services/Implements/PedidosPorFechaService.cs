using Lab08_RQuispe.Data.UnitOfWork;
using Lab08_RQuispe.Services.Interfaces;

namespace Lab08_RQuispe.Services.Implements;

public class PedidosPorFechaService : IPedidosPorFechaService
{
    private readonly IUnitOfWork _unitOfWork;

    public PedidosPorFechaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<object>> ObtenerPedidosDespuesDeFechaAsync(DateTime fecha)
    {
        var pedidos = await _unitOfWork.Orders.FindAsync(o => o.OrderDate > fecha);

        return pedidos.Select(o => new
        {
            o.OrderId,
            o.ClientId,
            o.OrderDate
        });
    }
}