using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VideoGameAPI_Example.Models;

namespace VideoGameAPI_Example.EntityConfigurations
{
    public class PlatformConfiguration : EntityTypeConfiguration<Platform>
    {
        public PlatformConfiguration()
        {
            // Table Overrides

            // Keys
            HasKey(p => p.Id);

            // Properties
            Property(p => p.Abbreviation)
            .IsRequired()
            .HasMaxLength(15);

            Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

            Property(p => p.Slug)
            .IsRequired()
            .HasMaxLength(15);

            Property(p => p.PlatformLogoId)
            .IsOptional();

            // Relationships
            HasRequired(p => p.Category)
            .WithMany(c => c.platforms)
            .HasForeignKey(p => p.CategoryId)
            .WillCascadeOnDelete(false);
        }
    }
}