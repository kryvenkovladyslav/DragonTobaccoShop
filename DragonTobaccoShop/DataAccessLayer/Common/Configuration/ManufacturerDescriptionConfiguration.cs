using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Common.Configuration
{
    public sealed class ManufacturerDescriptionConfiguration : IEntityTypeConfiguration<ManufacturerDescription>
    {
        public void Configure(EntityTypeBuilder<ManufacturerDescription> builder)
        {
            var description = builder.ToTable(nameof(ManufacturerDescription));
            description.HasKey(d => d.ID).HasName("ManufacturerDescription_PK_ID_Constraint");

            description.Property(d => d.ID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWID()")
                .IsRequired()
                .HasColumnName("ID");

            description.Property(d => d.Path)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasColumnName("Path");

            description.Property(d => d.ManufacturerID)
               .HasColumnType("UNIQUEIDENTIFIER")
               .IsRequired()
               .HasColumnName("ManufacturerID");
        }
    }
}