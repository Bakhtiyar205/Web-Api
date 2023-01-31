using System;
using E_Commerce.Application;
using E_Commerce.Domain.Entities;

namespace E_Commerce.Persistence.Concrete
{
	public class ProductService : IProductService
	{
		public ProductService()
		{
		}

		public List<Product> GetProducts() => new()
		{
			new()
			{
				Id = Guid.NewGuid(),
				Name = "Product 1",
				Price = 100,
				Stock = 10
			}
            ,
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Product 2",
                Price = 100,
                Stock = 10
            }
            ,
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Product 3",
                Price = 100,
                Stock = 10
            }
            ,
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Product 4",
                Price = 100,
                Stock = 10
            }
            ,
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Product 5",
                Price = 100,
                Stock = 10
            }
        };
    }
}

