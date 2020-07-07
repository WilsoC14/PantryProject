using PantryProject.Data.Entities;
using PantryProject_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject_Services.JoiningObjectServices
{
    public class Join_RecipeMenuService
    {
        public bool CreateRecipeInMenu(int recipeId, int menuId)
        {
            Join_RecipesInMenu entity = new Join_RecipesInMenu()
            {
                MenuId = menuId,
                RecipeId = recipeId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Join_RecipesInMenus.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipeFromMenu(int menuId, int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Join_RecipesInMenus
                                    .Where(r => r.RecipeId == recipeId)
                                    .Single(p => p.MenuId == menuId);


                ctx.Join_RecipesInMenus.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
