using DataAccessLayer.Common.Configuration;
using Domain.ApplicationModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.Common.Data
{
    public sealed class DatabaseContext : IdentityDbContext<User, Role, Guid>
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ManufacturerDescriptionConfiguration());
            builder.ApplyConfiguration(new TobaccoDescriptionConfiguration());
            builder.ApplyConfiguration(new TobaccosTastesConfiguration());
            builder.ApplyConfiguration(new CheckedProductConfiguration());
            builder.ApplyConfiguration(new ManufacturerConfiguration());
            builder.ApplyConfiguration(new TobaccoConfiguration());
            builder.ApplyConfiguration(new CartSessionConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());
            builder.ApplyConfiguration(new StrengthConfiguration());
            builder.ApplyConfiguration(new TasteConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UsersRolesConfiguration());
            builder.ApplyConfiguration(new WishListConfiguration());            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=DragonTobaccoShop;Trusted_Connection=True;");
        }
    }
}