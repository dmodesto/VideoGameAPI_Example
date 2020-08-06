namespace VideoGameAPI_Example.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreGenres : DbMigration
    {
        public override void Up()
        {
            // Insert More Genres
            Sql("SET IDENTITY_INSERT dbo.Genres ON");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (14, 'Sport', 'sport')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (15, 'Strategy', 'strategy')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (16, 'Turn-based strategy (TBS)', 'turn-based-strategy-tbs')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (24, 'Tactical', 'tactical')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (25, 'Hack and slash/Beat `em up', 'hack-and-slash-beat-em-up')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (26, 'Quiz/Trivia', 'quiz-trivia')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (30, 'Pinball', 'pinball')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (31, 'Adventure', 'adventure')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (33, 'Arcade', 'arcade')");
            Sql("INSERT INTO dbo.Genres (Id, Name, Slug) VALUES (34, 'Visual Novel', 'visual-novel')");
            Sql("SET IDENTITY_INSERT dbo.Genres OFF");
        }
        
        public override void Down()
        {
        }
    }
}
