using System;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Persistence.Contexts
{
    public class ECommerceApiDbContext : DbContext
    {
        public ECommerceApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : The property is that which catches changes or added items on Entities. It catches from Tracking.
            var  datas = ChangeTracker
                .Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdateDate = DateTime.Now,
                };
            }

            return await base.SaveChangesAsync(cancellationToken);

        }
    }
}

