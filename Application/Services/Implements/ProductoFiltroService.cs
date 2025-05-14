using Lab08_RQuispe.Data.UnitOfWork;
using Lab08_RQuispe.Services.interfaces;

namespace Lab08_RQuispe.Services.Implements;

public class ProductoFiltroService: IProductoFiltroService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductoFiltroService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<object>> ObtenerProductosConPrecioMayorAAsync(decimal precioMinimo)
    {
        var productos = await _unitOfWork.Products.FindAsync(p => p.Price > precioMinimo);
        return productos.Select(p => new
        {
            p.ProductId,
            p.Name,
            p.Price
        });
    }
}