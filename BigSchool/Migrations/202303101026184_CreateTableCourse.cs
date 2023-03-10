namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendance",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        Attendee = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CourseId, t.Attendee })
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LecturerId = c.String(maxLength: 128),
                        Name = c.String(maxLength: 255),
                        Place = c.String(maxLength: 255),
                        DateTime = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Following",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Attendance", "CourseId", "dbo.Course");
            DropIndex("dbo.Course", new[] { "CategoryId" });
            DropIndex("dbo.Attendance", new[] { "CourseId" });
            DropTable("dbo.Following");
            DropTable("dbo.Category");
            DropTable("dbo.Course");
            DropTable("dbo.Attendance");
        }
    }
}
