namespace Lab08_RQuispe.Services.interfaces;

public interface IClienteBusquedaService
{
    Task<IEnumerable<string>> BuscarClientesPorNombreAsync(string nombreParcial);
}