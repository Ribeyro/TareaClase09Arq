using Lab08_RQuispe.Application.DTOs;

namespace Lab08_RQuispe.Application.Services.Interfaces;

public interface IOrderDetailsService
{
    Task<List<OrderDetailsDto>> GetOrdersWithDetailsAsync();
}