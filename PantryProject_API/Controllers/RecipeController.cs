using PantryProject.Models.Recipe;
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
    }
}
