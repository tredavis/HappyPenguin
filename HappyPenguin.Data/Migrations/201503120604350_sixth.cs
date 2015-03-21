namespace HappyPenguin.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Image", c => c.String());
            DropColumn("dbo.Items", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Category", c => c.String());
            DropColumn("dbo.Items", "Image");
        }
    }
}
