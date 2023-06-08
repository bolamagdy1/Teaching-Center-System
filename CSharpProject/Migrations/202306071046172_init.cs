namespace CSharpProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        Day = c.String(),
                        Time = c.Double(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        HallId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Halls", t => t.HallId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.StudentId)
                .Index(t => t.HallId);
            
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        HallId = c.Int(nullable: false, identity: true),
                        HallNo = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HallId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Education_Stage = c.String(),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Subject = c.String(),
                        AvailableDay = c.String(),
                        AvailableTime_Start = c.Double(nullable: false),
                        AvailableTime_End = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        LessonId = c.Int(nullable: false, identity: true),
                        Day = c.String(),
                        Start_Time = c.Double(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        HallId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LessonId)
                .ForeignKey("dbo.Halls", t => t.HallId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.HallId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Lessons", "HallId", "dbo.Halls");
            DropForeignKey("dbo.Bookings", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Bookings", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Bookings", "HallId", "dbo.Halls");
            DropIndex("dbo.Lessons", new[] { "HallId" });
            DropIndex("dbo.Lessons", new[] { "TeacherId" });
            DropIndex("dbo.Bookings", new[] { "HallId" });
            DropIndex("dbo.Bookings", new[] { "StudentId" });
            DropIndex("dbo.Bookings", new[] { "TeacherId" });
            DropTable("dbo.Lessons");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Halls");
            DropTable("dbo.Bookings");
        }
    }
}
