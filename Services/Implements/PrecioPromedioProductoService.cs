using Lab08_RQuispe.Data.UnitOfWork;
using Lab08_RQuispe.Services.Interfaces;

namespace Lab08_RQuispe.Services.Implements;

public class PrecioPromedioProductoService : IPrecioPromedioProductoService
{
    private readonly IUnitOfWork _unitOfWork;

    public PrecioPromedioProductoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<decimal> CalcularPromedioPrecioAsync()
    {
        var productos = await _unitOfWork.Products.GetAllAsync();

        if (!productos.Any())
            return 0;

        return productos.Average(p => p.Price);
    }
}