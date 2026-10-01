namespace projec6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "_View", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "_View");
        }
    }
}
