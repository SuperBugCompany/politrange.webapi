namespace SuperBug.Politrange.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        KeywordId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KeywordId)
                .ForeignKey("dbo.Persons", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.PersonPageRanks",
                c => new
                    {
                        PersonPageRankId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        PageId = c.Int(nullable: false),
                        Rank = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonPageRankId)
                .ForeignKey("dbo.Pages", t => t.PageId, cascadeDelete: true)
                .ForeignKey("dbo.Persons", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                        Uri = c.String(unicode: false),
                        FoundDate = c.DateTime(nullable: false, precision: 0),
                        LastScanDate = c.DateTime(nullable: false, precision: 0),
                        SiteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PageId)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .Index(t => t.SiteId);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        SiteId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.SiteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Keywords", "PersonId", "dbo.Persons");
            DropForeignKey("dbo.PersonPageRanks", "PersonId", "dbo.Persons");
            DropForeignKey("dbo.PersonPageRanks", "PageId", "dbo.Pages");
            DropForeignKey("dbo.Pages", "SiteId", "dbo.Sites");
            DropIndex("dbo.Pages", new[] { "SiteId" });
            DropIndex("dbo.PersonPageRanks", new[] { "PageId" });
            DropIndex("dbo.PersonPageRanks", new[] { "PersonId" });
            DropIndex("dbo.Keywords", new[] { "PersonId" });
            DropTable("dbo.Sites");
            DropTable("dbo.Pages");
            DropTable("dbo.PersonPageRanks");
            DropTable("dbo.Persons");
            DropTable("dbo.Keywords");
        }
    }
}
