namespace Osahaneat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRestaurantTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Address", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Restaurants", "HolidayOfWeek", c => c.String(nullable: false, maxLength: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "HolidayOfWeek", c => c.String(nullable: false));
            DropColumn("dbo.Restaurants", "Address");
        }
    }
}
