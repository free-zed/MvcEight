namespace MvcEight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg44 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllTheStudent",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameOfClass = c.String(),
                        Roll = c.String(),
                        Name = c.String(),
                        FathersName = c.String(),
                        MothersName = c.String(),
                        Email = c.String(),
                        Cell = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AllTheStudent");
        }
    }
}
