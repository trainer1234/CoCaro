namespace CoCaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoTheGameIdField : DbMigration
    {
        public override void Up()
        {
            AddColumn("COCARO.Games", "CoTheGameId", c => c.Decimal(precision: 10, scale: 0));
        }
        
        public override void Down()
        {
            DropColumn("COCARO.Games", "CoTheGameId");
        }
    }
}
