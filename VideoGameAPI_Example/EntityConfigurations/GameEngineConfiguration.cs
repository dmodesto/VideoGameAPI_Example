using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VideoGameAPI_Example.Models;

namespace VideoGameAPI_Example.EntityConfigurations
{
    public class GameEngineConfiguration : EntityTypeConfiguration<GameEngine>
    {
        public GameEngineConfiguration()
        {
            // Table Overrides

            // Keys
            HasKey(ge => ge.Id);

            // Properties
            Property(ge => ge.Name)
            .IsRequired()
            .HasMaxLength(50);

            Property(ge => ge.Slug)
            .IsRequired()
            .HasMaxLength(50);

            // Relationships
        }
    }
}