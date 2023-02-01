using E_Commerce.Application.Repositories.OrderRepository;
using E_Commerce.Domain.Entities;
using E_Commerce.Persistence.Contexts;

namespace E_Commerce.Persistence.Repositories.OrderRepository;

public class OrderReadRepository : ReadRepository<Order>,IOrderReadRepository
{
    public OrderReadRepository(ECommerceApiDbContext context) : base(context)
    {
    }
}