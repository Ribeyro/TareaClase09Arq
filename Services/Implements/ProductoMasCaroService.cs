using Lab08_RQuispe.Data.UnitOfWork;
using Lab08_RQuispe.Services.Productos;

namespace Lab08_RQuispe.Services.Implements;

public class ProductoMasCaroService : IProductoMasCaroService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductoMasCaroService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<object?> ObtenerProductoMasCaroAsync()
    {
        var productos = await _unitOfWork.Products.GetAllAsync();
        var productoMasCaro = productos
            .OrderByDescending(p => p.Price)
            .FirstOrDefault();

        if (productoMasCaro == null) return null;

        return new
        {
            productoMasCaro.ProductId,
            productoMasCaro.Name,
            productoMasCaro.Price
        };
    }
}