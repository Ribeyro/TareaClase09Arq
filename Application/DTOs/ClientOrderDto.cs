namespace Lab08_RQuispe.Application.DTOs;

public class ClientOrderDto
{
    public string ClientName { get; set; }
    public List<OrderDto> Orders { get; set; }
}