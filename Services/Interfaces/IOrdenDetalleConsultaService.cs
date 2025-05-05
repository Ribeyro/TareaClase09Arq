namespace Lab08_RQuispe.Services.interfaces;

public interface IOrdenDetalleConsultaService
{
    Task<IEnumerable<object>> ObtenerDetallePorOrdenAsync(int orderId);
}