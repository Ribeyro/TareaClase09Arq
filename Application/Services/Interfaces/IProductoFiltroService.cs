namespace Lab08_RQuispe.Services.interfaces;

public interface IProductoFiltroService
{
    Task<IEnumerable<object>> ObtenerProductosConPrecioMayorAAsync(decimal precioMinimo);
}