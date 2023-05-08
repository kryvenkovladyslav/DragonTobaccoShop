using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Common.Configuration
{
    public sealed class TobaccosTastesConfiguration : IEntityTypeConfiguration<TobaccosTastes>
    {
        public void Configure(EntityTypeBuilder<TobaccosTastes> builder)
        {
            var usersRoles = builder.ToTable(nameof(TobaccosTastes));
            usersRoles.HasKey("TobaccoID", "TasteID").HasName("TobaccosTastes_PK_ID_Constraint");

            usersRoles.Property(tt => tt.TobaccoID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired()
                .HasColumnName("TobaccoID");

            usersRoles.Property(ur => ur.TasteID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired()
                .HasColumnName("TasteID");
        }
    }
}