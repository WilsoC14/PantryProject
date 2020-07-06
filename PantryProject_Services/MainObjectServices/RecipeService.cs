using PantryProject.Data.Entities;
using PantryProject.Models.Ingredient;
using PantryProject.Models.Menu;
using PantryProject.Models.PreparedItem;
using PantryProject.Models.Recipe;
using PantryProject_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject_Services.MainObjectServices
{
    public class RecipeService
    {
        public bool Create_Recipe(RecipeCreate model)
        {
            Recipe entity = new Recipe
            {
                Name = model.Name,

            };


            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipeListItem> Get_Recipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Recipes
                               .Select(
                                   i => new RecipeListItem
                                   {
                                       Id = i.Id,
                                       Name = i.Name,
                                   }
                                   );
                return query.ToList();
            }
        }

        public RecipeDetail Get_RecipeById(int id)
        {
            var listOfIngredients = new List<IngredientListItem>();
            var listOfPreparedItems = new List<PreparedItemListItem>();
            var listOfMenus = new List<MenuListItem>();
            //var ingredientService = new Ingredient_Service();
            using (var ctx = new ApplicationDbContext())
            {   // get prepared item by id, will need a trycatch if query returns null
                var entity = ctx.Recipes.Single(i => i.Id == id);
                // creates empty list to populate with ingredients.
                foreach (var ingredient in entity.Ingredients)
                {
                    var ingredientModel = new IngredientListItem()
                    {
                        Id = ingredient.IngredientId,
                        Name = ingredient.Ingredient.Name,
                        TypeOfIngredient = ingredient.Ingredient.TypeOfIngredient,
                        IngredientState = ingredient.Ingredient.IngredientState,
                    };
                    listOfIngredients.Add(ingredientModel);
                };
                foreach (var preppedItem in entity.PreparedItems)
                {
                    var preppedItemModel = new PreparedItemListItem()
                    {
                        Id = preppedItem.PreparedItemId,
                        Name = preppedItem.PreparedItem.Name,
                        StateOfPreparedItem = preppedItem.PreparedItem.StateOfPreparedItem,
                        TypeOfPreparedItem = preppedItem.PreparedItem.TypeOfPreparedItem
                    };
                    listOfPreparedItems.Add(preppedItemModel);
                }
                foreach (var menu in entity.Menus)
                {
                    var menuModel = new MenuListItem()
                    {
                        Id = menu.MenuId,
                        Name = menu.Menu.Name
                    };
                    listOfMenus.Add(menuModel);
                }
                var recipe = new RecipeDetail()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Ingredients = listOfIngredients,
                    PreparedItems = listOfPreparedItems,
                    Menus = listOfMenus
                };
                return recipe;
            }
        }

        public bool EditRecipe(RecipeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Recipes.SingleOrDefault(r => r.Id == model.Id);
                entity.Name = model.Name;

                if (!ctx.ChangeTracker.HasChanges())
                {
                    return true;
                }
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipe(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Recipes.SingleOrDefault(i => i.Id == id);

                ctx.Recipes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
