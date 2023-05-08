using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Common.Configuration
{
    public sealed class StrengthConfiguration : IEntityTypeConfiguration<Strength>
    {
        public void Configure(EntityTypeBuilder<Strength> builder)
        {
            var strength = builder.ToTable(nameof(Strength));
            strength.HasKey(s => s.ID).HasName("Strength_PK_ID_Constraint");

            strength.Property(s => s.ID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWID()")
                .IsRequired()
                .HasColumnName("ID");

            strength.Property(s => s.Kind)
                .HasColumnType("nvarchar")
                .HasMaxLength(30)
                .IsRequired()
                .HasColumnName("Kind");

            strength.HasMany(s => s.Tobaccos).WithOne(t => t.Strength)
                .HasForeignKey(t => t.StrengthID).HasPrincipalKey(s => s.ID)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false)
                .HasConstraintName("Tobacco_FK_Strength_ID_Constraint");
        }
    }
}