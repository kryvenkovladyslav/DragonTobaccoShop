using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Common.Configuration
{
    public sealed class CheckedProductConfiguration : IEntityTypeConfiguration<CheckedProduct>
    {
        public void Configure(EntityTypeBuilder<CheckedProduct> builder)
        {
            var checkedProduct = builder.ToTable(nameof(CheckedProduct));
            checkedProduct.HasKey(cp => cp.ID).HasName("CheckedProduct_PK_ID_Constraint");

            checkedProduct.Property(u => u.ID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWID()")
                .IsRequired()
                .HasColumnName("ID");

            checkedProduct.Property(u => u.UserID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired()
                .HasColumnName("UserID");

            checkedProduct.HasOne(cp => cp.Product).WithOne(p => p.CheckedProducts)
                .HasForeignKey<Product>(cp => cp.ID)
                .HasPrincipalKey<CheckedProduct>(cp => cp.ID)
                .HasConstraintName("Product_FK_CheckedProduct_ID_Constraint");

        }
    }
}