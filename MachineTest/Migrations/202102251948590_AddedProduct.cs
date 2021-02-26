namespace MachineTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Products", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Products");
            DropTable("dbo.Products");
        }
    }
}
