using PantryProject.Data.Entities;
using PantryProject_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject_Services.JoiningObjectServices
{
    public class Join_PreparedItemRecipeService
    {
        public bool CreatePreparedItemInRecipe(int preppedItemId, int recipeId)
        {
            Join_PreparedItemsInRecipe entity = new Join_PreparedItemsInRecipe()
            {
                PreparedItemId = preppedItemId,
                RecipeId = recipeId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Join_PreparedItemsInRecipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePreparedItemInRecipe(int preppedItemId, int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Join_PreparedItemsInRecipes
                                    .Where(r => r.RecipeId == recipeId)
                                    .Single(p => p.PreparedItemId == preppedItemId);


                ctx.Join_PreparedItemsInRecipes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }

}
