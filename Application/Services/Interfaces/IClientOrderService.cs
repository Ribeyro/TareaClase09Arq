using Lab08_RQuispe.Application.DTOs;

namespace Lab08_RQuispe.Application.Services.Interfaces;

public interface IClientOrderService
{
    Task<List<ClientOrderDto>> GetClientOrdersAsync();
}