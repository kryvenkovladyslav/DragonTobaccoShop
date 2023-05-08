using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Common.Configuration
{
    public sealed class TobaccoDescriptionConfiguration : IEntityTypeConfiguration<TobaccoDescription>
    {
        public void Configure(EntityTypeBuilder<TobaccoDescription> builder)
        {
            var description = builder.ToTable(nameof(TobaccoDescription));
            description.HasKey(d => d.ID).HasName("TobaccoDescription_PK_ID_Constraint");

            description.Property(d => d.ID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWID()")
                .IsRequired()
                .HasColumnName("ID");

            description.Property(d => d.Path)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasColumnName("Path");

            description.Property(d => d.TobaccoID)
               .HasColumnType("UNIQUEIDENTIFIER")
               .IsRequired()
               .HasColumnName("TobaccoID");
        }
    }
}