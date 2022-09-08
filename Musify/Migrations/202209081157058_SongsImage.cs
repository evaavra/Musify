namespace Musify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SongsImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "Thumbnail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "Thumbnail");
        }
    }
}
