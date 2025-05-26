using Lab08_RQuispe.Application.DTOs;
using Lab08_RQuispe.Application.Services.Interfaces;
using Lab08_RQuispe.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab08_RQuispe.Services.Implements;

public class ClientOrderService : IClientOrderService
{
    private readonly Lab08Context _context;

    public ClientOrderService(Lab08Context context)
    {
        _context = context;
    }

    public async Task<List<ClientOrderDto>> GetClientOrdersAsync()
    {
        return await _context.Clients
            .Include(client => client.Orders) // 👈 ¡Incluimos la relación!
            .AsNoTracking()
            .Select(client => new ClientOrderDto
            {
                ClientName = client.Name,
                Orders = client.Orders.Select(order => new OrderDto
                {
                    OrderId = order.OrderId,
                    OrderDate = order.OrderDate
                }).ToList()
            })
            .ToListAsync();
    }

}