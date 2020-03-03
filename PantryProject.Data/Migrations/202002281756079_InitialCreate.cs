namespace PantryProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TypeOfIngredient = c.Int(nullable: false),
                        IngredientState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Join_Ingredient_PreparedItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientId = c.Int(nullable: false),
                        PreparedItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredient", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.PreparedItem", t => t.PreparedItemId, cascadeDelete: true)
                .Index(t => t.IngredientId)
                .Index(t => t.PreparedItemId);
            
            CreateTable(
                "dbo.PreparedItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TypeOf_PreparedItem = c.Int(nullable: false),
                        StateOf_PreparedItem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Join_PreparedItem_Recipe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PreparedItemId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PreparedItem", t => t.PreparedItemId, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.PreparedItemId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Join_Ingredient_Recipe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredient", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.IngredientId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Join_Recipe_Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menu", t => t.MenuId, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Join_Ingredient_PreparedItem", "PreparedItemId", "dbo.PreparedItem");
            DropForeignKey("dbo.Join_PreparedItem_Recipe", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.Join_Recipe_Menu", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.Join_Recipe_Menu", "MenuId", "dbo.Menu");
            DropForeignKey("dbo.Join_Ingredient_Recipe", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.Join_Ingredient_Recipe", "IngredientId", "dbo.Ingredient");
            DropForeignKey("dbo.Join_PreparedItem_Recipe", "PreparedItemId", "dbo.PreparedItem");
            DropForeignKey("dbo.Join_Ingredient_PreparedItem", "IngredientId", "dbo.Ingredient");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Join_Recipe_Menu", new[] { "MenuId" });
            DropIndex("dbo.Join_Recipe_Menu", new[] { "RecipeId" });
            DropIndex("dbo.Join_Ingredient_Recipe", new[] { "RecipeId" });
            DropIndex("dbo.Join_Ingredient_Recipe", new[] { "IngredientId" });
            DropIndex("dbo.Join_PreparedItem_Recipe", new[] { "RecipeId" });
            DropIndex("dbo.Join_PreparedItem_Recipe", new[] { "PreparedItemId" });
            DropIndex("dbo.Join_Ingredient_PreparedItem", new[] { "PreparedItemId" });
            DropIndex("dbo.Join_Ingredient_PreparedItem", new[] { "IngredientId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Menu");
            DropTable("dbo.Join_Recipe_Menu");
            DropTable("dbo.Join_Ingredient_Recipe");
            DropTable("dbo.Recipe");
            DropTable("dbo.Join_PreparedItem_Recipe");
            DropTable("dbo.PreparedItem");
            DropTable("dbo.Join_Ingredient_PreparedItem");
            DropTable("dbo.Ingredient");
        }
    }
}
