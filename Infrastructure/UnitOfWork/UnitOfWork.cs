using Lab08_RQuispe.Data.Repository.Implements;
using Lab08_RQuispe.Data.Repository.Interfaces;
using Lab08_RQuispe.Models;

namespace Lab08_RQuispe.Data.UnitOfWork;

public class UnitOfWork: IUnitOfWork
{
    private readonly Lab08Context _context;

    public UnitOfWork(Lab08Context context)
    {
        _context = context;
        Clients = new GenericRepository<Client>(_context);
        Products = new GenericRepository<Product>(_context);
        Orders = new GenericRepository<Order>(_context);
        Orderdetails = new GenericRepository<Orderdetail>(_context);
    }

    public IGenericRepository<Client> Clients { get; }
    public IGenericRepository<Product> Products { get; }
    public IGenericRepository<Order> Orders { get; }
    public IGenericRepository<Orderdetail> Orderdetails { get; }

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}