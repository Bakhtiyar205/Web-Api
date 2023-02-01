using E_Commerce.Application.Repositories.ProductRepository;
using E_Commerce.Domain.Entities;
using E_Commerce.Persistence.Contexts;

namespace E_Commerce.Persistence.Repositories.ProductRepository;

public class ProductWriteRepository : WriteRepository<Product>,IProductWriteRepository
{
    public ProductWriteRepository(ECommerceApiDbContext context) : base(context)
    {
    }
}