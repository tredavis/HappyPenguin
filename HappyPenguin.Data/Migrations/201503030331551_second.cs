namespace HappyPenguin.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HappyCarts",
                c => new
                    {
                        HappyCartId = c.Int(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemsId = c.Int(nullable: false),
                        HappyShopperId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HappyCartId)
                .ForeignKey("dbo.HappyShoppers", t => t.HappyShopperId, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ItemsId, cascadeDelete: true)
                .Index(t => t.ItemsId)
                .Index(t => t.HappyShopperId);
            
            CreateTable(
                "dbo.HappyShoppers",
                c => new
                    {
                        HappyShopperId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        State = c.String(),
                        TX = c.String(),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HappyShopperId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemsId = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ItemsId);
            
            CreateTable(
                "dbo.RecentlyBoughts",
                c => new
                    {
                        RecentlyBoughtId = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HappyCartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecentlyBoughtId)
                .ForeignKey("dbo.HappyCarts", t => t.HappyCartId, cascadeDelete: true)
                .Index(t => t.HappyCartId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RecentlyBoughts", "HappyCartId", "dbo.HappyCarts");
            DropForeignKey("dbo.HappyCarts", "ItemsId", "dbo.Items");
            DropForeignKey("dbo.HappyCarts", "HappyShopperId", "dbo.HappyShoppers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RecentlyBoughts", new[] { "HappyCartId" });
            DropIndex("dbo.HappyCarts", new[] { "HappyShopperId" });
            DropIndex("dbo.HappyCarts", new[] { "ItemsId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RecentlyBoughts");
            DropTable("dbo.Items");
            DropTable("dbo.HappyShoppers");
            DropTable("dbo.HappyCarts");
        }
    }
}
