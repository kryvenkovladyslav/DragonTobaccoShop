using Abstractions.ApplicationModels;
using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Common.Configuration
{
    public sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            var userRole = builder.ToTable(nameof(UserRole));


            userRole.HasOne(ur => ur.Role).WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId).HasPrincipalKey(r => r.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            userRole.HasOne(ur => ur.User).WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId).HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}