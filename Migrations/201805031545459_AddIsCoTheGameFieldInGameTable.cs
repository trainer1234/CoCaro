namespace CoCaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCoTheGameFieldInGameTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("COCARO.Games", "IsCoTheGame", c => c.Decimal(precision: 1, scale: 0));
        }
        
        public override void Down()
        {
            DropColumn("COCARO.Games", "IsCoTheGame");
        }
    }
}
