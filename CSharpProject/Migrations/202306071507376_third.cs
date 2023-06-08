namespace CSharpProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Lesson_LessonId", c => c.Int());
            CreateIndex("dbo.Students", "Lesson_LessonId");
            AddForeignKey("dbo.Students", "Lesson_LessonId", "dbo.Lessons", "LessonId");
            DropColumn("dbo.Lessons", "End_Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "End_Time", c => c.String());
            DropForeignKey("dbo.Students", "Lesson_LessonId", "dbo.Lessons");
            DropIndex("dbo.Students", new[] { "Lesson_LessonId" });
            DropColumn("dbo.Students", "Lesson_LessonId");
        }
    }
}
