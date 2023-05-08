using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Common.Configuration
{
    public sealed class WishListConfiguration : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            var wishLish = builder.ToTable(nameof(WishList));
            wishLish.HasKey(wl => wl.ID).HasName("WishList_PK_ID_Constraint");

            wishLish.Property(wl => wl.ID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWID()")
                .IsRequired()
                .HasColumnName("ID");

            wishLish.HasMany(wl => wl.Products).WithOne(p => p.WishList)
                .HasForeignKey(p => p.WishListID).HasPrincipalKey(w => w.ID)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false)
                .HasConstraintName("Product_FK_WishList_ID_Constraint");
        }
    }
}