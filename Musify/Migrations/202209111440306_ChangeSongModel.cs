namespace Musify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSongModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "SongPath", c => c.String());
            DropColumn("dbo.Songs", "Youtube");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "Youtube", c => c.String());
            DropColumn("dbo.Songs", "SongPath");
        }
    }
}
