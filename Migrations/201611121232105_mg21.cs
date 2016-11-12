namespace MvcEight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BengaliTwoEight",
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BengaliTwoEight");
        }
    }
}
