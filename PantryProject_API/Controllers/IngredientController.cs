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
            Ingredient_Service ingredientService = CreateIngredientService();
            var ingredients = ingredientService.GetAll_Ingredients();
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
       
        public IHttpActionResult Post_CreateIngredient(IngredientCreate model)
        { // put in some logic to prevent duplicate ingredient to be created.
            var ingredientService = CreateIngredientService();
            if (ingredientService.IngredientExists(model.Name))
            {
                return BadRequest("Ingredient Already Exists");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!ingredientService.Create_Ingredient(model))
                return InternalServerError();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Put_IngredientByName(IngredientEdit model)
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

        private Ingredient_Service CreateIngredientService()
        {
            return  new Ingredient_Service();
        }

    }
}
