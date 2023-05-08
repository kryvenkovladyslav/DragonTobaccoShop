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

            checkedProduct.Property(cp => cp.Date)
               .HasColumnType("date")
               .IsRequired()
               .HasColumnName("Date");

            checkedProduct.Property(cp => cp.UserID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired()
                .HasColumnName("UserID");

            checkedProduct.Property(cp => cp.ProductID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired()
                .HasColumnName("ProductID");

            checkedProduct.HasOne(cp => cp.Product).WithMany(p => p.CheckedProducts)
                .HasForeignKey(cp => cp.ProductID).HasPrincipalKey(p => p.ID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .HasConstraintName("Product_FK_CheckedProduct_ID_Constraint");

        }
    }
}