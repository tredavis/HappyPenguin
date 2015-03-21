namespace HappyPenguin.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ItemName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "ItemName");
        }
    }
}
