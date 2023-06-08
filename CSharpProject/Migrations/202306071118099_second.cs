namespace CSharpProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "End_Time", c => c.String());
            AlterColumn("dbo.Bookings", "Time", c => c.String());
            AlterColumn("dbo.Teachers", "AvailableTime_Start", c => c.String());
            AlterColumn("dbo.Teachers", "AvailableTime_End", c => c.String());
            AlterColumn("dbo.Lessons", "Start_Time", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lessons", "Start_Time", c => c.Double(nullable: false));
            AlterColumn("dbo.Teachers", "AvailableTime_End", c => c.Double(nullable: false));
            AlterColumn("dbo.Teachers", "AvailableTime_Start", c => c.Double(nullable: false));
            AlterColumn("dbo.Bookings", "Time", c => c.Double(nullable: false));
            DropColumn("dbo.Lessons", "End_Time");
        }
    }
}
