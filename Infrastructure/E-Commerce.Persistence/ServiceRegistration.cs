using System;
using E_Commerce.Application.Repositories;
using E_Commerce.Application.Repositories.CustomerRepository;
using E_Commerce.Application.Repositories.OrderRepository;
using E_Commerce.Application.Repositories.ProductRepository;
using E_Commerce.Persistence.Contexts;
using E_Commerce.Persistence.Repositories.CustomerRepository;
using E_Commerce.Persistence.Repositories.OrderRepository;
using E_Commerce.Persistence.Repositories.ProductRepository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceService(this IServiceCollection services)
		{
			services.AddDbContext<ECommerceApiDbContext>(options => options.UseSqlServer(Configurations.ConnectionString));
			services.AddScoped<IProductReadRepository, ProductReadRepository>();
			services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
			services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
			services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
			services.AddScoped<IOrderReadRepository, OrderReadRepository>();
			services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

		}
	}
}

