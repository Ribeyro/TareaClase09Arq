using Lab08_RQuispe.Application.DTOs;
using Lab08_RQuispe.Application.Services.Interfaces;
using Lab08_RQuispe.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab08_RQuispe.Services.Implements;

public class ClientProductCountService : IClientProductCountService
{
    private readonly Lab08Context _context;

    public ClientProductCountService(Lab08Context context)
    {
        _context = context;
    }

    public async Task<List<ClientProductCountDto>> GetClientsWithProductCountAsync()
    {
        return await _context.Clients
            .AsNoTracking()
            .Select(client => new ClientProductCountDto
            {
                ClientName = client.Name,
                TotalProducts = client.Orders
                    .SelectMany(order => order.Orderdetails)
                    .Sum(detail => detail.Quantity)
            }).ToListAsync();
    }
}