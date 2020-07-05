namespace VideoGameAPI_Example.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            // Insert Game Engines
            Sql("SET IDENTITY_INSERT dbo.Genres ON");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (2, 'Point-and-click', 'point-and-click')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (4, 'Fighting', 'fighting')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (5, 'Shooter', 'shooter')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (7, 'Music', 'music')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (8, 'Platform', 'platform')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (9, 'Puzzle', 'puzzle')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (10, 'Racing', 'racing')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (11, 'Real Time Strategy (RTS)', 'real-time-strategy-rts')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (12, 'Role-playing (RPG)', 'role-playing-rpg')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (13, 'Simulator', 'simulator')");
            Sql("SET IDENTITY_INSERT dbo.Genres OFF");
        }
        
        public override void Down()
        {
            DropTable("dbo.Genres");
        }
    }
}
