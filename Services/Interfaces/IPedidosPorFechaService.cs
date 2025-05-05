namespace Lab08_RQuispe.Services.Interfaces;

public interface IPedidosPorFechaService
{
    Task<IEnumerable<object>> ObtenerPedidosDespuesDeFechaAsync(DateTime fecha);
}