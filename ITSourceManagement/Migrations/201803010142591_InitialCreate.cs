namespace ITSourceManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComputerSources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeatId = c.Int(nullable: false),
                        Number = c.String(),
                        Date = c.DateTime(nullable: false),
                        Belongs = c.Int(nullable: false),
                        SeatSource_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SeatSources", t => t.SeatSource_Id)
                .Index(t => t.SeatSource_Id);
            
            CreateTable(
                "dbo.SeatSources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeatNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComputerSources", "SeatSource_Id", "dbo.SeatSources");
            DropIndex("dbo.ComputerSources", new[] { "SeatSource_Id" });
            DropTable("dbo.SeatSources");
            DropTable("dbo.ComputerSources");
        }
    }
}
