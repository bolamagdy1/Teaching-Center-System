namespace CSharpProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finallll : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "Level", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "Level", c => c.String());
        }
    }
}
