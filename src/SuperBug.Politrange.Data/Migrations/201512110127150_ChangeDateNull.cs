namespace SuperBug.Politrange.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pages", "FoundDate", c => c.DateTime(precision: 0));
            AlterColumn("dbo.Pages", "LastScanDate", c => c.DateTime(precision: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pages", "LastScanDate", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Pages", "FoundDate", c => c.DateTime(nullable: false, precision: 0));
        }
    }
}
