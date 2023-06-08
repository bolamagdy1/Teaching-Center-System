namespace CSharpProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "Capacity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lessons", "Capacity");
        }
    }
}
