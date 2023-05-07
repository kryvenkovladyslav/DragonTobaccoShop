using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Common.Configuration
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var user = builder.ToTable(nameof(User));
            user.HasKey(u => u.Id).HasName("User_PK_ID_Constraint");

            user.Property(u => u.Id)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWID()")
                .IsRequired()
                .HasColumnName("ID");

            user.Property(u => u.FirstName)
                .HasColumnType("nvarchar")
                .HasMaxLength(70)
                .IsRequired()
                .HasColumnName("FirstName");

            user.Property(u => u.LastName)
                .HasColumnType("nvarchar")
                .HasMaxLength(70)
                .IsRequired()
                .HasColumnName("LastName");

            user.Property(u => u.RegistraionDate)
                .HasColumnType("date")
                .IsRequired()
                .HasColumnName("RegistrationDate");

            user.Property(u => u.BirthDay)
                .HasColumnType("date")
                .IsRequired()
                .HasColumnName("BirthDay");

            user.HasOne(u => u.WishList).WithOne(w => w.User)
                .HasForeignKey<WishList>(w => w.ID)
                .HasPrincipalKey<User>(u => u.Id)
                .HasConstraintName("WithList_FK_User_ID_Constraint");

            user.HasMany(u => u.Orders).WithOne(o => o.User)
                .HasForeignKey(o => o.UserID).HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .HasConstraintName("Order_FK_User_ID_Constraint");

            user.HasMany(u => u.CartSessions).WithOne(o => o.User)
                .HasForeignKey(cs => cs.UserID).HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .HasConstraintName("CartSession_FK_User_ID_Constraint");

            user.HasMany(u => u.Reviews).WithOne(o => o.User)
                .HasForeignKey(r => r.UserID).HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .HasConstraintName("Review_FK_User_ID_Constraint");

            user.HasMany(u => u.CheckedProducts).WithOne(o => o.User)
               .HasForeignKey(cp => cp.UserID).HasPrincipalKey(u => u.Id)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired()
               .HasConstraintName("CheckedProduct_FK_User_ID_Constraint");
        }
    }
}