using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Common.Configuration
{
    public sealed class TobaccoConfiguration : IEntityTypeConfiguration<Tobacco>
    {
        public void Configure(EntityTypeBuilder<Tobacco> builder)
        {
            var tobacco = builder.ToTable(nameof(Tobacco));
            tobacco.HasKey(t => t.ID).HasName("Tobacco_PK_ID_Constraint");

            tobacco.Property(t => t.ID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWID()")
                .IsRequired()
                .HasColumnName("ID");

            tobacco.Property(t => t.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(150)
                .IsRequired()
                .HasColumnName("Name");

            tobacco.Property(t => t.Weight)
                .HasColumnType("float")
                .IsRequired()
                .HasColumnName("Weight");

            tobacco.Property(t => t.Leaf)
                .HasColumnType("nvarchar")
                .HasMaxLength(150)
                .IsRequired(false)
                .HasColumnName("Leaf");

            tobacco.Property(t => t.Package)
                .HasColumnType("nvarchar")
                .HasMaxLength(40)
                .IsRequired(false)
                .HasColumnName("Package");

            tobacco.Property(t => t.Slicing)
                .HasColumnType("nvarchar")
                .HasMaxLength(30)
                .IsRequired(false)
                .HasColumnName("Slicing");

            tobacco.Property(t => t.Country)
                .HasColumnType("nvarchar")
                .HasMaxLength(30)
                .IsRequired(false)
                .HasColumnName("County");

            tobacco.Property(t => t.IsMint)
                .HasColumnType("bit")
                .IsRequired()
                .HasColumnName("IsMint");

            tobacco.Property(t => t.IsIced)
                .HasColumnType("bit")
                .IsRequired()
                .HasColumnName("IsIced");

            tobacco.Property(t => t.IsMixed)
                .HasColumnType("bit")
                .IsRequired()
                .HasColumnName("IsMixed");

            tobacco.Property(t => t.IsSmoky)
                .HasColumnType("bit")
                .IsRequired()
                .HasColumnName("IsSmoky");

            tobacco.Property(t => t.IsSweet)
                .HasColumnType("bit")
                .IsRequired()
                .HasColumnName("IsSweet");

            tobacco.Property(t => t.ManufacturerID)
               .HasColumnType("UNIQUEIDENTIFIER")
               .IsRequired(false)
               .HasColumnName("ManufacturerID");

            tobacco.Property(t => t.StrengthID)
               .HasColumnType("UNIQUEIDENTIFIER")
               .IsRequired(false)
               .HasColumnName("StrengthID");

            tobacco.HasMany(t => t.Tastes).WithOne(tt => tt.Tobacco)
               .HasForeignKey(tt => tt.TobaccoID).HasPrincipalKey(t => t.ID)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired()
               .HasConstraintName("TobaccosTastes_FK_Tobacco_ID_Constraint");
        }
    }
}