using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Common.Configuration
{
    public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            var role = builder.ToTable(nameof(Role));
            role.HasKey(u => u.Id).HasName("Role_PK_ID_Constraint");

            role.HasMany(r => r.UsersRoles).WithOne(ur => ur.Role)
               .HasForeignKey(ur => ur.RoleId).HasPrincipalKey(r => r.Id)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired()
               .HasConstraintName("UsersRoles_FK_Role_ID_Constraint");
        }
    }
}