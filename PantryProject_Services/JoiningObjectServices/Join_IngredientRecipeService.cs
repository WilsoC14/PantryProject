using PantryProject.Data.Entities;
using PantryProject_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject_Services.JoiningObjectServices
{
    public class Join_IngredientRecipeService
    {
        public bool CreateIngredientInRecipe(int ingredientId, int recipeId)
        {
            Join_IngredientsInRecipe entity = new Join_IngredientsInRecipe()
            {
                IngredientId = ingredientId,
                RecipeId = recipeId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Join_IngredientsInRecipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool Delete_JoinIngredientPreparedItem(int ingredientId, int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Join_IngredientsInRecipes
                                    .Where(r => r.RecipeId == recipeId)
                                    .Single(p => p.IngredientId == ingredientId);


                ctx.Join_IngredientsInRecipes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
