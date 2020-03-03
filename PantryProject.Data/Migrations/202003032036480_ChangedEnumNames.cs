namespace PantryProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedEnumNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Join_PreparedItem_Recipe", newName: "Join_PreparedItemsInRecipe");
            RenameTable(name: "dbo.Join_Ingredient_Recipe", newName: "Join_IngredientsInRecipe");
            RenameTable(name: "dbo.Join_Recipe_Menu", newName: "Join_RecipesInMenu");
            DropForeignKey("dbo.Join_Ingredient_PreparedItem", "IngredientId", "dbo.Ingredient");
            DropForeignKey("dbo.Join_Ingredient_PreparedItem", "PreparedItemId", "dbo.PreparedItem");
            DropIndex("dbo.Join_Ingredient_PreparedItem", new[] { "IngredientId" });
            DropIndex("dbo.Join_Ingredient_PreparedItem", new[] { "PreparedItemId" });
            CreateTable(
                "dbo.Join_IngredientsInPreparedItem",
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
            
            AddColumn("dbo.PreparedItem", "TypeOfPreparedItem", c => c.Int(nullable: false));
            AddColumn("dbo.PreparedItem", "StateOfPreparedItem", c => c.Int(nullable: false));
            DropColumn("dbo.PreparedItem", "TypeOf_PreparedItem");
            DropColumn("dbo.PreparedItem", "StateOf_PreparedItem");
            DropTable("dbo.Join_Ingredient_PreparedItem");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Join_Ingredient_PreparedItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientId = c.Int(nullable: false),
                        PreparedItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PreparedItem", "StateOf_PreparedItem", c => c.Int(nullable: false));
            AddColumn("dbo.PreparedItem", "TypeOf_PreparedItem", c => c.Int(nullable: false));
            DropForeignKey("dbo.Join_IngredientsInPreparedItem", "PreparedItemId", "dbo.PreparedItem");
            DropForeignKey("dbo.Join_IngredientsInPreparedItem", "IngredientId", "dbo.Ingredient");
            DropIndex("dbo.Join_IngredientsInPreparedItem", new[] { "PreparedItemId" });
            DropIndex("dbo.Join_IngredientsInPreparedItem", new[] { "IngredientId" });
            DropColumn("dbo.PreparedItem", "StateOfPreparedItem");
            DropColumn("dbo.PreparedItem", "TypeOfPreparedItem");
            DropTable("dbo.Join_IngredientsInPreparedItem");
            CreateIndex("dbo.Join_Ingredient_PreparedItem", "PreparedItemId");
            CreateIndex("dbo.Join_Ingredient_PreparedItem", "IngredientId");
            AddForeignKey("dbo.Join_Ingredient_PreparedItem", "PreparedItemId", "dbo.PreparedItem", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Join_Ingredient_PreparedItem", "IngredientId", "dbo.Ingredient", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Join_RecipesInMenu", newName: "Join_Recipe_Menu");
            RenameTable(name: "dbo.Join_IngredientsInRecipe", newName: "Join_Ingredient_Recipe");
            RenameTable(name: "dbo.Join_PreparedItemsInRecipe", newName: "Join_PreparedItem_Recipe");
        }
    }
}
