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
        private IngredientService _ingredientService = new IngredientService();
        [HttpGet]
        public IHttpActionResult GetAll_Ingredients()
        {
            return Ok(_ingredientService.GetAll_Ingredients());
        }
        [HttpGet]
        public IHttpActionResult Get_IngredientByName(string name)
        {        
            return Ok(_ingredientService.Get_IngredientByName(name));
        }
        [HttpGet]
        public IHttpActionResult Get_IngredientById(int id)
        {           
            return Ok(_ingredientService.Get_IngredientById(id));
        }
        [HttpPost]
       
        public IHttpActionResult Post_CreateIngredient(IngredientCreate model)
        {
           
            if (_ingredientService.IngredientExists(model.Name))
            {
                return BadRequest("Ingredient Already Exists");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_ingredientService.Create_Ingredient(model))
                return InternalServerError();
            return Ok();
        }
        [Route("PutIngredientByName")]
        [HttpPut]
        public IHttpActionResult Put_IngredientByName(IngredientEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_ingredientService.Edit_IngredientByName(model))
                return InternalServerError();
            return Ok();
        }
        [Route("PutIngredientById")]
        [HttpPut]
        public IHttpActionResult Put_IngredientById(IngredientEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_ingredientService.Edit_IngredientById(model))
                return InternalServerError();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete_IngredientByName(string name)
        {
           
            if (!_ingredientService.Delete_IngredientByName(name))
                return InternalServerError();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete_IngredientById(int id)
        {

            if (!_ingredientService.Delete_IngredientById(id)) 
                return InternalServerError();
            return Ok();
        }
        //private IngredientService CreateIngredientService()
        //{
        //    return  new IngredientService();
        //}

    }
}
