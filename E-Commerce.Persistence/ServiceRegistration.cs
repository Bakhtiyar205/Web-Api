using System;
using E_Commerce.Application;
using E_Commerce.Persistence.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services)
		{
			services.AddSingleton<IProductService, ProductService>();
		}
	}
}

