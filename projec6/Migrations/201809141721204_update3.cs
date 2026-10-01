namespace projec6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transaction", "Email", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "Email", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
    }
}
