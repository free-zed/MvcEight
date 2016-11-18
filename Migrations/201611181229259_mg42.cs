namespace MvcEight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg42 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllTheTeacher",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Cell = c.Int(nullable: false),
                        NameOfClass = c.String(),
                        Subject = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AllTheTeacher");
        }
    }
}
