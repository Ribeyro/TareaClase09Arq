using Lab08_RQuispe.Application.DTOs;
using Lab08_RQuispe.Application.Services.Interfaces;
using Lab08_RQuispe.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab08_RQuispe.Services.Implements;

public class SalesByClientService : ISalesByClientService
{
    private readonly Lab08Context _context;

    public SalesByClientService(Lab08Context context)
    {
        _context = context;
    }

    public async Task<List<SalesByClientDto>> GetSalesByClientAsync()
    {
        return await _context.Orders
            .Include(o => o.Orderdetails)
            .ThenInclude(od => od.Product)
            .AsNoTracking()
            .GroupBy(order => order.ClientId)
            .Select(group => new SalesByClientDto
            {
                ClientName = _context.Clients
                    .FirstOrDefault(c => c.ClientId == group.Key).Name,
                TotalSales = group.Sum(order =>
                    order.Orderdetails.Sum(detail =>
                        detail.Quantity * detail.Product.Price))
            })
            .OrderByDescending(s => s.TotalSales)
            .ToListAsync();
    }
}