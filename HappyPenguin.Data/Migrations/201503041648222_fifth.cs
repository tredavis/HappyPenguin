namespace HappyPenguin.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HappyCarts", "ItemsId", "dbo.Items");
            DropIndex("dbo.HappyCarts", new[] { "ItemsId" });
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemsId = c.Int(nullable: false, identity: true),
                        ItemsId = c.Int(nullable: false),
                        DatePurchased = c.DateTime(),
                        HappyShopperId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderItemsId)
                // Turn off the cascadeDelete from "true" to "false"
                .ForeignKey("dbo.HappyShoppers", t => t.HappyShopperId, cascadeDelete: false)
                // Turn off the cascadeDelete from "true" to "false"
                .ForeignKey("dbo.Items", t => t.ItemsId, cascadeDelete: false)
                .Index(t => t.ItemsId)
                .Index(t => t.HappyShopperId);
            
            AddColumn("dbo.HappyCarts", "OrderItemsId", c => c.Int(nullable: false));
            CreateIndex("dbo.HappyCarts", "OrderItemsId");
            // Turn off the cascadeDelete from "true" to "false"
            AddForeignKey("dbo.HappyCarts", "OrderItemsId", "dbo.OrderItems", "OrderItemsId", cascadeDelete: false);
            DropColumn("dbo.HappyCarts", "ItemsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HappyCarts", "ItemsId", c => c.Int(nullable: false));
            DropForeignKey("dbo.HappyCarts", "OrderItemsId", "dbo.OrderItems");
            DropForeignKey("dbo.OrderItems", "ItemsId", "dbo.Items");
            DropForeignKey("dbo.OrderItems", "HappyShopperId", "dbo.HappyShoppers");
            DropIndex("dbo.OrderItems", new[] { "HappyShopperId" });
            DropIndex("dbo.OrderItems", new[] { "ItemsId" });
            DropIndex("dbo.HappyCarts", new[] { "OrderItemsId" });
            DropColumn("dbo.HappyCarts", "OrderItemsId");
            DropTable("dbo.OrderItems");
            CreateIndex("dbo.HappyCarts", "ItemsId");
            AddForeignKey("dbo.HappyCarts", "ItemsId", "dbo.Items", "ItemsId", cascadeDelete: true);
        }
    }
}
