namespace Lab08_RQuispe.Services.Interfaces;

public interface IProductosSinDescripcionService
{
    Task<IEnumerable<object>> ObtenerProductosSinDescripcionAsync();
}