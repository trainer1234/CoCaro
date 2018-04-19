namespace CoCaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "COCARO.Games",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Winner = c.Decimal(nullable: false, precision: 10, scale: 0),
                        StartTime = c.DateTime(nullable: false),
                        Duration = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "COCARO.Moves",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        GameId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Point = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("COCARO.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("COCARO.Moves", "GameId", "COCARO.Games");
            DropIndex("COCARO.Moves", new[] { "GameId" });
            DropTable("COCARO.Moves");
            DropTable("COCARO.Games");
        }
    }
}
