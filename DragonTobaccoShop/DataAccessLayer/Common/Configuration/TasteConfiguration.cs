using Domain.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Common.Configuration
{
    public sealed class TasteConfiguration : IEntityTypeConfiguration<Taste>
    {
        public void Configure(EntityTypeBuilder<Taste> builder)
        {
            var taste = builder.ToTable(nameof(Taste));
            taste.HasKey(t => t.ID).HasName("Taste_PK_ID_Constraint");

            taste.Property(t => t.ID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWID()")
                .IsRequired()
                .HasColumnName("ID");

            taste.Property(t => t.Name)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasColumnName("Name");

            taste.HasMany(t => t.Tobaccos).WithOne(tt => tt.Taste)
                .HasForeignKey(tt => tt.TasteID).HasPrincipalKey(t => t.ID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .HasConstraintName("TobaccosTastes_FK_Taste_ID_Constraint");
        }
    }
}