namespace Osahaneat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 30),
                        PhoneNumber = c.String(nullable: false, maxLength: 10),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Token = c.String(maxLength: 50),
                        Created = c.DateTime(nullable: false),
                        IsActived = c.Boolean(nullable: false),
                        UserType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Created = c.DateTime(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.RestaurantId)
                .Index(t => t.CustomerId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MealId = c.Int(nullable: false),
                        OrderListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meals", t => t.MealId, cascadeDelete: false)
                .ForeignKey("dbo.OrderLists", t => t.OrderListId, cascadeDelete: false)
                .Index(t => t.MealId)
                .Index(t => t.OrderListId);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        KitchenId = c.Int(nullable: false),
                        CategoryMealId = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryMeals", t => t.CategoryMealId, cascadeDelete: false)
                .ForeignKey("dbo.Kitchens", t => t.KitchenId, cascadeDelete: false)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: false)
                .Index(t => t.KitchenId)
                .Index(t => t.CategoryMealId)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.CategoryMeals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kitchens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HolidayOfWeek = c.String(nullable: false),
                        OpenHours = c.Int(nullable: false),
                        ClooseHours = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        PlaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.PlaceId);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(),
                        MealId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meals", t => t.MealId, cascadeDelete: false)
                .Index(t => t.MealId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderLists", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "OrderListId", "dbo.OrderLists");
            DropForeignKey("dbo.Reviews", "MealId", "dbo.Meals");
            DropForeignKey("dbo.Restaurants", "UserId", "dbo.Users");
            DropForeignKey("dbo.Restaurants", "PlaceId", "dbo.Places");
            DropForeignKey("dbo.OrderLists", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Meals", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Orders", "MealId", "dbo.Meals");
            DropForeignKey("dbo.Meals", "KitchenId", "dbo.Kitchens");
            DropForeignKey("dbo.Meals", "CategoryMealId", "dbo.CategoryMeals");
            DropForeignKey("dbo.Customers", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderLists", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Reviews", new[] { "MealId" });
            DropIndex("dbo.Restaurants", new[] { "PlaceId" });
            DropIndex("dbo.Restaurants", new[] { "UserId" });
            DropIndex("dbo.Meals", new[] { "RestaurantId" });
            DropIndex("dbo.Meals", new[] { "CategoryMealId" });
            DropIndex("dbo.Meals", new[] { "KitchenId" });
            DropIndex("dbo.Orders", new[] { "OrderListId" });
            DropIndex("dbo.Orders", new[] { "MealId" });
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropIndex("dbo.OrderLists", new[] { "User_Id" });
            DropIndex("dbo.OrderLists", new[] { "CustomerId" });
            DropIndex("dbo.OrderLists", new[] { "RestaurantId" });
            DropIndex("dbo.Admins", new[] { "UserId" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Places");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Kitchens");
            DropTable("dbo.CategoryMeals");
            DropTable("dbo.Meals");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.OrderLists");
            DropTable("dbo.Users");
            DropTable("dbo.Admins");
        }
    }
}
