using PantryProject.Models.Ingredient;
using PantryProject_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PantryProject_API.Controllers
{   [Authorize]
    [RoutePrefix("api/Ingredient")]
    public class IngredientController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll_Ingredients()
        {
            IngredientService ingredientService = CreateIngredientService();
            var ingredients = ingredientService.Get_AllIngredients();
            return Ok(ingredients);   //what is exactly happening when you pass the list into the Ok() 
        }
        [HttpGet]
        public IHttpActionResult Get_IngredientByName(string name)
        {
            var ingredientService = CreateIngredientService();
            var ingredient = ingredientService.Get_IngredientByName(name);
            return Ok(ingredient);

        }
        [HttpGet]
        public IHttpActionResult Get_IngredientById(int id)
        {
            var ingredientService = CreateIngredientService();
            var ingredient = ingredientService.Get_IngredientById(id);
            return Ok(ingredient);
        }
        [HttpPost]
       
        public IHttpActionResult Post_CreateIngredient(Ingredient_Create model)
        { // put in some logic to prevent duplicate ingredient to be created.
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var ingredientService = CreateIngredientService();

            if (!ingredientService.Create_Ingredient(model))
                return InternalServerError();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Put_IngredientByName(Ingredient_Edit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ingredientService = CreateIngredientService();

            if (!ingredientService.Edit_IngredientByName(model))
                return InternalServerError();
            return Ok();

        }
        [HttpDelete]
        public IHttpActionResult Delete_IngredientByName(string name)
        {
            var ingredientService = CreateIngredientService();
            if (!ingredientService.Delete_IngredientByName(name))
                return InternalServerError();
            return Ok();
        }

        private IngredientService CreateIngredientService()
        {
            return  new IngredientService();
        }

    }
}
