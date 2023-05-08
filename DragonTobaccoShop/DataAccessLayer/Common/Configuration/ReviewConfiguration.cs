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
    public sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            var review = builder.ToTable(nameof(Review));
            review.HasKey(r => r.ID).HasName("Review_PK_ID_Constraint");
            
            review.Property(r => r.Text)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasColumnName("Text");

            review.Property(r => r.ID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWID()")
                .IsRequired()
                .HasColumnName("ID");

            review.Property(r => r.Evaluation)
                 .HasColumnType("int")
                 .HasDefaultValue(1)
                 .IsRequired()
                 .HasColumnName("Evaluation");

            review.Property(r => r.UserID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired()
                .HasColumnName("UserID");

            review.Property(r => r.ProductID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired()
                .HasColumnName("UserID");

            review.HasOne(r => r.Product).WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductID).HasPrincipalKey(p => p.ID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false)
                .HasConstraintName("Review_FK_Product_ID_Constraint");

        }
    }
}