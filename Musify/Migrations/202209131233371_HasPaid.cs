namespace Musify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HasPaid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "HasPaid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "HasPaid");
        }
    }
}
