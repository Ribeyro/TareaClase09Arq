using Lab08_RQuispe.Data.Repository.Interfaces;
using Lab08_RQuispe.Models;

namespace Lab08_RQuispe.Data.UnitOfWork;

public interface IUnitOfWork: IDisposable
{
    IGenericRepository<Client> Clients { get; }
    IGenericRepository<Product> Products { get; }
    IGenericRepository<Order> Orders { get; }
    IGenericRepository<Orderdetail> Orderdetails { get; }

    Task<int> CompleteAsync();
}