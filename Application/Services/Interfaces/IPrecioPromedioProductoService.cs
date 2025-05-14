namespace Lab08_RQuispe.Services.Interfaces;

public interface IPrecioPromedioProductoService
{
    Task<decimal> CalcularPromedioPrecioAsync();
}