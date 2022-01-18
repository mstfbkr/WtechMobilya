using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilya.DataAccess
{
    public class MobilyaDBContext : IdentityDbContext<Users, UserRole, int>
    {
        public MobilyaDBContext()
        {
        }
        public DbSet<Users> users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public MobilyaDBContext(DbContextOptions<MobilyaDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
