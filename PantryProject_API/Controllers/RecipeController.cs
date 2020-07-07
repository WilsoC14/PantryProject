using PantryProject.Models.Recipe;
using PantryProject_Services.JoiningObjectServices;
using PantryProject_Services.MainObjectServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PantryProject_API.Controllers
{
    [RoutePrefix("api/Recipe")]
    public class RecipeController : ApiController
    {
        private readonly RecipeService _recipeService = new RecipeService();
        private readonly Join_IngredientRecipeService _ingredientInRecipeService = new Join_IngredientRecipeService();
        private readonly Join_PreparedItemRecipeService _preparedItemInRecipeService = new Join_PreparedItemRecipeService();
        [HttpGet]
        public IHttpActionResult GetAllRecipes()
        {
            return Ok(_recipeService.Get_Recipes());
        }
        [HttpGet]
        public IHttpActionResult GetRecipeById(int id)
        {
            return Ok(_recipeService.Get_RecipeById(id));
        }
        [HttpPost]
        public IHttpActionResult CreateRecipe(RecipeCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_recipeService.Create_Recipe(model))
                return InternalServerError();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult PutRecipe(RecipeEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_recipeService.EditRecipe(model))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteRecipe(int id)
        {
            if (!_recipeService.DeleteRecipe(id))
                return InternalServerError();
            return Ok();
        }
        [HttpPost]
        [Route("AddIngredient")]
        public IHttpActionResult AddIngredient(int ingredientId, int recipeId)
        {
            if (!_ingredientInRecipeService.CreateIngredientInRecipe(ingredientId, recipeId))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        [Route("RemoveIngredient")]
        public IHttpActionResult RemoveIngredient(int ingredientId, int recipeId)
        {
            if (!_ingredientInRecipeService.Delete_JoinIngredientPreparedItem(ingredientId, recipeId))
                return InternalServerError();
            return Ok();
        }
        [HttpPost]
        [Route("AddPreparedItem")]
        public IHttpActionResult AddPreparedItem(int preparedItemId, int recipeId)
        {
            if (!_preparedItemInRecipeService.CreatePreparedItemInRecipe(preparedItemId, recipeId))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        [Route("RemovePreparedItem")]
        public IHttpActionResult DeletePreparedItem(int preparedItemId, int recipeId)
        {
            if (!_preparedItemInRecipeService.DeletePreparedItemInRecipe(preparedItemId, recipeId))
                return InternalServerError();
            return Ok();
        }
    }
    }
