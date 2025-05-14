namespace Lab08_RQuispe.Services.Interfaces;

public interface IProductosPorClienteService
{
    Task<IEnumerable<object>> ObtenerProductosVendidosPorClienteAsync(int clientId);
}