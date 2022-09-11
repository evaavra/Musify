namespace Musify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class artistinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "Info", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "Info");
        }
    }
}
