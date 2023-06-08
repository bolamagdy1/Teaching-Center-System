namespace CSharpProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Level", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Level");
        }
    }
}
