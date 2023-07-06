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
        }
    }
}