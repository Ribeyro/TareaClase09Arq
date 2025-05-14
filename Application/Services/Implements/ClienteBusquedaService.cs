using Lab08_RQuispe.Data.UnitOfWork;
using Lab08_RQuispe.Services.interfaces;

namespace Lab08_RQuispe.Services.Implements;

public class ClienteBusquedaService: IClienteBusquedaService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClienteBusquedaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<string>> BuscarClientesPorNombreAsync(string nombreParcial)
    {
        var clientes = await _unitOfWork.Clients.FindAsync(c => c.Name.StartsWith(nombreParcial));
        return clientes.Select(c => c.Name);
    }
}