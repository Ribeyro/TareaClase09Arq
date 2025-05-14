namespace Lab08_RQuispe.Services.interfaces;

public interface IOrdenCantidadTotalService
{
    Task<int> ObtenerCantidadTotalPorOrdenAsync(int orderId);
}