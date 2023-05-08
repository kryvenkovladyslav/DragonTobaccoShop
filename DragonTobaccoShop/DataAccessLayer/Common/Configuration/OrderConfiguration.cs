using Abstractions.Common;
using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Common.Configuration
{
    public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            var order = builder.ToTable(nameof(Order));
            order.HasKey(o => o.ID).HasName("Order_PK_ID_Constraint");

            order.Property(o => o.ID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWID()")
                .IsRequired()
                .HasColumnName("ID");

            order.Property(o => o.Status)
                .HasColumnType("nvarchar")
                .HasMaxLength(35)
                .HasDefaultValue(OrderStatus.Registered)
                .IsRequired()
                .HasColumnName("Status");

            order.Property(o => o.TototalPrice)
                .HasColumnType("decimal")
                .HasDefaultValue(0)
                .IsRequired()
                .HasColumnName("TotalPrice");

            order.Property(o => o.UserID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired()
                .HasColumnName("UserID");

            order.HasMany(o => o.Items).WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderID).HasPrincipalKey(o => o.ID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .HasConstraintName("Order_FK_OrderItem_ID_Constraint");
        }
    }
}