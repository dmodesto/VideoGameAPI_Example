namespace VideoGameAPI_Example.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDatabase : DbMigration
    {
        public override void Up()
        {
            // Insert Game Engines
            Sql("SET IDENTITY_INSERT dbo.GameEngines ON");
            Sql("INSERT INTO dbo.GameEngines (Id, Name, Slug) VALUES (6, 'Unreal Engine', 'unreal-engine')");
            Sql("INSERT INTO dbo.GameEngines (Id, Name, Slug) VALUES (13, 'Unity', 'unity')");
            Sql("INSERT INTO dbo.GameEngines (Id, Name, Slug) VALUES (203, 'UE4 - duplicate', 'ue4-duplicate')");
            Sql("INSERT INTO dbo.GameEngines (Id, Name, Slug) VALUES (351, 'Unreal Engine 3', 'unreal-engine-3')");
            Sql("INSERT INTO dbo.GameEngines (Id, Name, Slug) VALUES (404, 'Unity 4', 'unity-4')");
            Sql("INSERT INTO dbo.GameEngines (Id, Name, Slug) VALUES (439, 'Unreal Engine 4', 'unreal-engine-4--1')");
            Sql("INSERT INTO dbo.GameEngines (Id, Name, Slug) VALUES (509, 'Unity 2017', 'unity-2017')");
            Sql("INSERT INTO dbo.GameEngines (Id, Name, Slug) VALUES (529, 'Unity 5', 'unity-5')");
            Sql("INSERT INTO dbo.GameEngines (Id, Name, Slug) VALUES (601, 'Unity 2018', 'unity-2018')");
            Sql("SET IDENTITY_INSERT dbo.GameEngines OFF");

            // Insert Categories first since Platforms has a Foriegn key to them
            Sql("SET IDENTITY_INSERT dbo.Categories ON");
            Sql("INSERT INTO dbo.Categories (Id, Name) VALUES (1, 'console')");
            Sql("INSERT INTO dbo.Categories (Id, Name) VALUES (5, 'portable_console')");
            Sql("SET IDENTITY_INSERT dbo.Categories OFF");

            // Insert Platforms
            // PlayStation
            Sql("SET IDENTITY_INSERT dbo.Platforms ON");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (7, 'PlayStation', 1, 'PS1', 'ps', 278)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (8, 'PlayStation 2', 1, 'PS2', 'ps2', 254)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (9, 'PlayStation 3', 1, 'PS3', 'ps3', 79)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (38, 'PlayStation Portable', 5, 'PSP', 'psp', 214)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (46, 'PlayStation Vita', 5, 'VITA', 'psvita', 232)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (48, 'PlayStation 4', 1, 'PS4', 'ps4--1', 231)");       
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (165, 'PlayStation VR', 1, 'PSVR', 'playstation-vr', 161)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (167, 'PlayStation 5', 1, 'PS5', 'playstation-5', null)");
            // Xbox
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (11, 'Xbox', 1, 'XBOX', 'xbox', 266)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (12, 'Xbox 360', 1, 'X360', 'xbox360', 250)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (49, 'Xbox One', 1, 'XONE', 'xboxone', null)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (169, 'Xbox Series X', 1, 'XBOXSERIESX', 'xbox-series-x', 327)");
            // Nintendo
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (4, 'Nintendo 64', 1, 'N64', 'n64', 260)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (18, 'Nintendo Entertainment System (NES)', 1, 'NES', 'nes', 229)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (19, 'Super Nintendo Entertainment System (SNES)', 1, 'SNES', 'snes--1', 106)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (20, 'Nintendo DS', 5, 'NDS', 'nds', 245)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (21, 'Nintendo GameCube', 1, 'NGC', 'ngc', 262)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (22, 'Game Boy Color', 5, 'GBC', 'gbc', 273)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (24, 'Game Boy Advance', 5, 'GBA', 'gba', 255)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (33, 'Game Boy', 5, 'Game Boy', 'gb', 274)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (37, 'Nintendo 3DS', 5, '3DS', '3ds', 240)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (87, 'Virtual Boy', 1, 'virturalboy', 'virtualboy', 280)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (130, 'Nintendo Switch', 1, 'Switch', 'switch', 227)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (137, 'New Nintendo DS', 5, 'N3DS', 'new-nintendo-ds', 235)");
            Sql("INSERT INTO dbo.Platforms (Id, Name, CategoryId, Abbreviation, Slug, PlatformLogoId) " +
                "VALUES (159, 'Nintendo DSi', 5, 'DSI', 'nintendo-dsi', 246)");
            Sql("SET IDENTITY_INSERT dbo.Platforms OFF");
        }
        
        public override void Down()
        {
            Sql("TRUNCATE TABLE dbo.Platforms");
            Sql("DELETE FROM dbo.Categories");
            Sql("TRUNCATE TABLE dbo.GameEngines");       
        }
    }
}
