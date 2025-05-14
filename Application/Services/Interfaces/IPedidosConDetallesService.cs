namespace Lab08_RQuispe.Services.Interfaces;

public interface IPedidosConDetallesService
{
    Task<IEnumerable<object>> ObtenerPedidosConDetallesAsync();
}