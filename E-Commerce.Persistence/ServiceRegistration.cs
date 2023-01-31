using System;
using E_Commerce.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceService(this IServiceCollection services)
		{
			services.AddDbContext<ECommerceApiDbContext>(options => options.UseSqlServer(Configurations.ConnectionString));
		}
	}
}

