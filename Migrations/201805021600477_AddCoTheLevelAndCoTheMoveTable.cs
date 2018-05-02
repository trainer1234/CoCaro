namespace CoCaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoTheLevelAndCoTheMoveTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "COCARO.CoTheLevels",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        LimitedMove = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "COCARO.CoTheMoves",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CoTheLevelId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Point = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("COCARO.CoTheLevels", t => t.CoTheLevelId, cascadeDelete: true)
                .Index(t => t.CoTheLevelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("COCARO.CoTheMoves", "CoTheLevelId", "COCARO.CoTheLevels");
            DropIndex("COCARO.CoTheMoves", new[] { "CoTheLevelId" });
            DropTable("COCARO.CoTheMoves");
            DropTable("COCARO.CoTheLevels");
        }
    }
}
