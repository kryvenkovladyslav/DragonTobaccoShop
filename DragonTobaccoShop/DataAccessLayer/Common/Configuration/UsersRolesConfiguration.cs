using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Common.Configuration
{
    public sealed class UsersRolesConfiguration : IEntityTypeConfiguration<UsersRoles>
    {
        public void Configure(EntityTypeBuilder<UsersRoles> builder)
        {
            var usersRoles = builder.ToTable(nameof(UsersRoles));

            usersRoles.Property(ur => ur.UserId)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired()
                .HasColumnName("UserID");

            usersRoles.Property(ur => ur.RoleId)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired()
                .HasColumnName("RoleID");
        }
    }
}