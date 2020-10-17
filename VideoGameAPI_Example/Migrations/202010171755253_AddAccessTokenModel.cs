namespace VideoGameAPI_Example.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccessTokenModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        Type = c.String(),
                        ExpiresIn = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccessTokens");
        }
    }
}
