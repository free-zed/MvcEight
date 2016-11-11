namespace MvcEight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bengali",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Roll = c.String(),
                        SBA = c.Double(nullable: false),
                        Final = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        GPA = c.Double(nullable: false),
                        Grade = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.English",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Roll = c.String(),
                        SBA = c.Double(nullable: false),
                        Final = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        GPA = c.Double(nullable: false),
                        Grade = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
            DropTable("dbo.English");
            DropTable("dbo.Bengali");
        }
    }
}
