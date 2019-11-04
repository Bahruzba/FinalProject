namespace Osahaneat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixbug1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "HolidayOfWeek", c => c.String(nullable: false, maxLength: 21));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "HolidayOfWeek", c => c.String(nullable: false, maxLength: 7));
        }
    }
}
