using System;
using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Persistence.Contexts
{
	public class ECommerceApiDbContext:DbContext
	{
		public ECommerceApiDbContext(DbContextOptions options):base(options)
		{

		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}

