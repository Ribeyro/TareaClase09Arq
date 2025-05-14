using Lab08_RQuispe.Data.UnitOfWork;
using Lab08_RQuispe.Services.Interfaces;

namespace Lab08_RQuispe.Services.Implements;

public class ClienteMayorPedidosService : IClienteMayorPedidosService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClienteMayorPedidosService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<object?> ObtenerClienteConMasPedidosAsync()
    {
        var pedidos = await _unitOfWork.Orders.GetAllAsync();
        var clientes = await _unitOfWork.Clients.GetAllAsync();

        var resultado = pedidos
            .GroupBy(o => o.ClientId)
            .Select(g => new
            {
                ClientId = g.Key,
                TotalPedidos = g.Count()
            })
            .OrderByDescending(x => x.TotalPedidos)
            .FirstOrDefault();

        if (resultado == null) return null;

        var cliente = clientes.FirstOrDefault(c => c.ClientId == resultado.ClientId);

        return new
        {
            resultado.ClientId,
            Cliente = cliente?.Name,
            resultado.TotalPedidos
        };
    }
}