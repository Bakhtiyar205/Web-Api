using E_Commerce.Application.Repositories.CustomerRepository;
using E_Commerce.Persistence.Contexts;

namespace E_Commerce.Persistence.Repositories.CustomerRepository;

public class CustomerReadRepository : ReadRepository<Domain.Entities.Customer>, ICustomerReadRepository
{
    public CustomerReadRepository(ECommerceApiDbContext context) : base(context)
    {
    }
}