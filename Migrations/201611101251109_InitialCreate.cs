namespace MvcEight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        EventDate = c.DateTime(nullable: false),
                        EventPlace = c.String(),
                        EventDetails = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Exam",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExamDate = c.DateTime(nullable: false),
                        ExamSubject = c.String(),
                        ExamSyllabus = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Holiday",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VacationFor = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ClassResumesOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Holiday");
            DropTable("dbo.Exam");
            DropTable("dbo.Event");
        }
    }
}
