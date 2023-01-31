using System;
using E_Commerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace E_Commerce.Persistence
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceApiDbContext>
	{
		public DesignTimeDbContextFactory()
		{
		}

        public ECommerceApiDbContext CreateDbContext(string[] args)
        {
            

            DbContextOptionsBuilder<ECommerceApiDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configurations.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}

