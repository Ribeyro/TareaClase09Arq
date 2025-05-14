namespace Lab08_RQuispe.Services.Interfaces;

public interface IClientesPorProductoService
{
    Task<IEnumerable<string>> ObtenerClientesPorProductoAsync(int productId);
}