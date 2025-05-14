namespace Lab08_RQuispe.Services.Interfaces;

public interface IClienteMayorPedidosService
{
    Task<object?> ObtenerClienteConMasPedidosAsync();
}