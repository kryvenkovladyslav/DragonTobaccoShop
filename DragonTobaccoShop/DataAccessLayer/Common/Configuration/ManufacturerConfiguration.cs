using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Common.Configuration
{
    public sealed class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            var manufacturer = builder.ToTable(nameof(Manufacturer));
            manufacturer.HasKey(m => m.ID).HasName("Manufacturer_PK_ID_Constraint");

            manufacturer.Property(m => m.ID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWID()")
                .IsRequired()
                .HasColumnName("ID");

            manufacturer.Property(m => m.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(70)
                .IsRequired()
                .HasColumnName("Name");

            manufacturer.Property(m => m.ImagePath)
                .HasColumnType("nvarchar")
                .HasMaxLength(70)
                .IsRequired()
                .HasColumnName("ImagePath");

            manufacturer.HasMany(m => m.Tobaccos).WithOne(t => t.Manufacturer)
                .HasForeignKey(t => t.ManufacturerID).HasPrincipalKey(s => s.ID)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false)
                .HasConstraintName("Tobacco_FK_Manufacturer_ID_Constraint");

            manufacturer.HasMany(m => m.Descriptions).WithOne(d => d.Manufacturer)
                .HasForeignKey(d => d.ManufacturerID).HasPrincipalKey(m => m.ID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .HasConstraintName("ManufacturerDescription_FK_Manufacturer_ID_Constraint");
        }
    }
}
