using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Common.Configuration
{
    public sealed class CartSessionConfiguration : IEntityTypeConfiguration<CartSession>
    {
        public void Configure(EntityTypeBuilder<CartSession> builder)
        {
            var cartSession = builder.ToTable(nameof(CartSession));
            cartSession.HasKey(cs => cs.ID).HasName("CartSession_PK_ID_Constraint");

            cartSession.Property(cs => cs.ID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWID()")
                .IsRequired()
                .HasColumnName("ID");

            cartSession.Property(cs => cs.UserID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired()
                .HasColumnName("UserID");
        }
    }
}