namespace projec6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Status = c.Boolean(nullable: false),
                        Createtime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCategory = c.Int(),
                        IdBrand = c.Int(),
                        Name = c.String(nullable: false, maxLength: 100),
                        Price = c.Int(nullable: false),
                        Sale = c.Int(nullable: false),
                        Color = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Image = c.String(nullable: false, maxLength: 300, unicode: false),
                        Sex = c.Int(nullable: false),
                        Title = c.String(nullable: false, storeType: "ntext"),
                        Tcontent = c.String(nullable: false, storeType: "ntext"),
                        Status = c.Boolean(nullable: false),
                        Createtime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.IdCategory, cascadeDelete: true)
                .ForeignKey("dbo.Brand", t => t.IdBrand, cascadeDelete: true)
                .Index(t => t.IdCategory)
                .Index(t => t.IdBrand);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Status = c.Boolean(nullable: false),
                        Sex = c.Int(nullable: false),
                        Createtime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProduct = c.Int(),
                        Name = c.String(maxLength: 300),
                        Status = c.Boolean(nullable: false),
                        Createtime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.IdProduct, cascadeDelete: true)
                .Index(t => t.IdProduct);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTransaction = c.Int(),
                        IdProduct = c.Int(),
                        Price = c.Double(),
                        Sale = c.Double(),
                        Quantity = c.Int(),
                        Receive = c.Boolean(),
                        Createtime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Transaction", t => t.IdTransaction, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.IdProduct, cascadeDelete: true)
                .Index(t => t.IdTransaction)
                .Index(t => t.IdProduct);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(),
                        IdPay = c.Int(),
                        First_name = c.String(nullable: false, maxLength: 50),
                        Last_name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 20, fixedLength: true),
                        Security = c.String(maxLength: 6, unicode: false),
                        Createtime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pay", t => t.IdPay, cascadeDelete: true)
                .Index(t => t.IdPay);
            
            CreateTable(
                "dbo.Pay",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                        Createtime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cnt = c.String(storeType: "ntext"),
                        Createtime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Letter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(),
                        First_name = c.String(nullable: false, maxLength: 30, fixedLength: true),
                        Last_name = c.String(nullable: false, maxLength: 30, fixedLength: true),
                        Email = c.String(maxLength: 100, unicode: false),
                        Address = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(maxLength: 20),
                        Textcontent = c.String(nullable: false, storeType: "ntext"),
                        Title = c.String(nullable: false, unicode: false, storeType: "text"),
                        Status = c.Boolean(nullable: false),
                        Createtime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Slider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Title = c.String(nullable: false, maxLength: 100),
                        Status = c.Boolean(nullable: false),
                        Createtime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        First_name = c.String(nullable: false, maxLength: 20, fixedLength: true),
                        Last_name = c.String(nullable: false, maxLength: 20, fixedLength: true),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Passwold = c.String(nullable: false, maxLength: 20, unicode: false),
                        Passwold2 = c.String(nullable: false),
                        Sex = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 20, unicode: false),
                        Address = c.String(nullable: false, maxLength: 200, fixedLength: true),
                        Avatar = c.String(nullable: false, maxLength: 300, unicode: false),
                        Access = c.Int(nullable: false),
                        status = c.Boolean(nullable: false),
                        Createtime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "IdBrand", "dbo.Brand");
            DropForeignKey("dbo.Order", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.Transaction", "IdPay", "dbo.Pay");
            DropForeignKey("dbo.Order", "IdTransaction", "dbo.Transaction");
            DropForeignKey("dbo.Image", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.Products", "IdCategory", "dbo.Category");
            DropIndex("dbo.Transaction", new[] { "IdPay" });
            DropIndex("dbo.Order", new[] { "IdProduct" });
            DropIndex("dbo.Order", new[] { "IdTransaction" });
            DropIndex("dbo.Image", new[] { "IdProduct" });
            DropIndex("dbo.Products", new[] { "IdBrand" });
            DropIndex("dbo.Products", new[] { "IdCategory" });
            DropTable("dbo.User");
            DropTable("dbo.Slider");
            DropTable("dbo.Letter");
            DropTable("dbo.Client");
            DropTable("dbo.Pay");
            DropTable("dbo.Transaction");
            DropTable("dbo.Order");
            DropTable("dbo.Image");
            DropTable("dbo.Category");
            DropTable("dbo.Products");
            DropTable("dbo.Brand");
        }
    }
}
