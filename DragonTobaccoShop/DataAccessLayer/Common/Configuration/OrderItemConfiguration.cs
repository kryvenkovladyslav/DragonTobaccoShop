using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Common.Configuration
{
    public sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            var orderItem = builder.ToTable(nameof(OrderItem));
            orderItem.HasKey(oi => oi.ID).HasName("OrderItem_PK_ID_Constraint");

            orderItem.Property(oi => oi.ID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWID()")
                .IsRequired()
                .HasColumnName("ID");

            orderItem.Property(oi => oi.Count)
                .HasColumnType("int")
                .HasDefaultValue(1)
                .IsRequired()
                .HasColumnName("Count");

            orderItem.Property(oi => oi.OrderID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired()
                .HasColumnName("OrderID");

            orderItem.Property(oi => oi.CartSessionID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired(false)
                .HasColumnName("CartSessionID");

            orderItem.Property(oi => oi.ProductID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired(false)
                .HasColumnName("ProductID");

            orderItem.HasOne(oi => oi.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductID).HasPrincipalKey(p => p.ID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .HasConstraintName("OrderItem_FK_Product_ID_Constraint");
        }
    }
}