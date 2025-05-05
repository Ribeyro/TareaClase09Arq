using Lab08_RQuispe.Data.UnitOfWork;
using Lab08_RQuispe.Services.Interfaces;

namespace Lab08_RQuispe.Services.Implements;

public class ProductosSinDescripcionService : IProductosSinDescripcionService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductosSinDescripcionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<object>> ObtenerProductosSinDescripcionAsync()
    {
        var productos = await _unitOfWork.Products.FindAsync(p =>
            string.IsNullOrEmpty(p.Description));

        return productos.Select(p => new
        {
            p.ProductId,
            p.Name,
            p.Price
        });
    }
}