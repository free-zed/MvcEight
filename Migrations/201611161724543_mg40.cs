namespace MvcEight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg40 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassNineStudent",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Roll = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Cell = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClassNineStudent");
        }
    }
}
