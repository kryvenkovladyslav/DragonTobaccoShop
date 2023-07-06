using Abstractions.Models;
using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Common.Configuration
{
    public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            var product = builder.ToTable(nameof(Product));
            product.HasKey(p => p.ID).HasName("Product_PK_ID_Constraint");

            product.Property(p => p.ID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWID()")
                .IsRequired()
                .HasColumnName("ID");

            product.Property(p => p.Price)
                .HasColumnType("decimal")
                .IsRequired()
                .HasColumnName("Price");

            product.Property(p => p.IsAvailable)
                .HasColumnType("bit")
                .IsRequired()
                .HasColumnName("IsAvailable");

            product.Property(p => p.Discount)
                .HasColumnType("int")
                .IsRequired()
                .HasColumnName("Discount");

            product.Property(p => p.ImagePath)
                .HasColumnType("nvarchar")
                .IsRequired(false)
                .HasColumnName("ImagePath");

            product.Property(p => p.WishListID)
               .HasColumnType("UNIQUEIDENTIFIER")
               .IsRequired(false)
               .HasColumnName("WishListID");

            product.HasOne(p=> p.Tobacco).WithOne(t => t.Product)
                .HasForeignKey<Product>(p => p.ID).HasPrincipalKey<Tobacco>(t => t.ID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .HasConstraintName("Product_FK_Tobacco_ID_Constraint");
        }
    }
}