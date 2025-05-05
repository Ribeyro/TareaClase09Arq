using Lab08_RQuispe.Data.UnitOfWork;
using Lab08_RQuispe.Services.Interfaces;

namespace Lab08_RQuispe.Services.Implements;

public class ClientesPorProductoService : IClientesPorProductoService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientesPorProductoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<string>> ObtenerClientesPorProductoAsync(int productId)
    {
        var detalles = await _unitOfWork.Orderdetails.FindAsync(d => d.ProductId == productId);
        var ordenes = await _unitOfWork.Orders.GetAllAsync();
        var clientes = await _unitOfWork.Clients.GetAllAsync();

        var resultado = from d in detalles
            join o in ordenes on d.OrderId equals o.OrderId
            join c in clientes on o.ClientId equals c.ClientId
            select c.Name;

        return resultado.Distinct().ToList();
    }
}