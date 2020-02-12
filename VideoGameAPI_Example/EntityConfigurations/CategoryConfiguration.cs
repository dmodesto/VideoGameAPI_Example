using System;
using System.Data.Entity.ModelConfiguration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameAPI_Example.Models;

namespace VideoGameAPI_Example.EntityConfigurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            // Table Overrides

            // Keys
            HasKey(c => c.Id);

            // Properties
            Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);

            // Relationships
        }
    }
}