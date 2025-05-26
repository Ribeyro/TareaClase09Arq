using Lab08_RQuispe.Application.DTOs;
using Lab08_RQuispe.Application.Services.Interfaces;
using Lab08_RQuispe.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab08_RQuispe.Services.Implements;

public class OrderDetailsService : IOrderDetailsService
{
    private readonly Lab08Context _context;

    public OrderDetailsService(Lab08Context context)
    {
        _context = context;
    }

    public async Task<List<OrderDetailsDto>> GetOrdersWithDetailsAsync()
    {
        return await _context.Orders
            .Include(order => order.Orderdetails)
            .ThenInclude(od => od.Product)
            .AsNoTracking()
            .Select(order => new OrderDetailsDto
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                Products = order.Orderdetails.Select(od => new ProductDto
                {
                    ProductName = od.Product.Name,
                    Quantity = od.Quantity,
                    Price = od.Product.Price
                }).ToList()
            }).ToListAsync();
    }
}