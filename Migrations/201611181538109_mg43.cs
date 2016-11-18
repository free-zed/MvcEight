namespace MvcEight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg43 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllTheCourse",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        CourseTeacher = c.String(),
                        CourseOfClass = c.String(),
                        Division = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AllTheCourse");
        }
    }
}
