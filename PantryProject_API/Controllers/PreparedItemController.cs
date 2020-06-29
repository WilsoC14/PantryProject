using PantryProject.Data.Entities;
using PantryProject.Models.JoiningModels;
using PantryProject.Models.PreparedItem;
using PantryProject_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PantryProject_API.Controllers
{

    [Authorize]
    [RoutePrefix("api/PreparedItem")]
    public class PreparedItemController : ApiController
    {
        private readonly PreparedItem_Service _piService = new PreparedItem_Service();

        [HttpGet]
        public IHttpActionResult GetAll_PreparedItems()
        {
            return Ok(_piService.Get_AllPreparedItems());   // ugly, change name
        }
        [HttpGet]
        public IHttpActionResult Get_PreparedItemByName(string name)
        {          
            return Ok(_piService.Get_PreparedItemByName(name));
        }
        [HttpGet]
        public IHttpActionResult Get_PreparedItemById(int id)
        {
            return Ok(_piService.Get_PreparedItemById(id));
        }
        [Route("PutPreparedItemByName")]
        [HttpPut]
        public IHttpActionResult Put_PreparedItemByName(PreparedItemEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_piService.Edit_PreparedItemByName(model))
                return InternalServerError();
            return Ok();
        }
        [Route("PutPreparedItemById")]
        [HttpPut]
        public IHttpActionResult Put_PreparedItemById(PreparedItemEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_piService.Edit_PreparedItemById(model)) 
                return InternalServerError();
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult Post_CreatePreparedItem(PreparedItemCreate model)
        { // put in some logic to prevent duplicate ingredient to be created.
            if (_piService.PreparedItemExists(model.Name))
            {
                return BadRequest("Item Already Exists");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_piService.Create_PreparedItem(model))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete_PreparedItemByName(string name)
        {
            if (!_piService.Delete_PreparedItemByName(name))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete_PreparedItemById(int id)
        {
            if (!_piService.Delete_PreparedItemById(id))
                return InternalServerError();
            return Ok();
        }
        [HttpPost]
        [Route("AddIngredient")]
        public IHttpActionResult Add_IngredientToPreparedItem(AddIngredientToPreparedItem model)
        {
            if (!_piService.Add_IngredientToPrepairedItem(model))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        [Route("RemoveIngredient")]
        public IHttpActionResult Delete_IngredientFromPreparedItem(int preparedItemId, int ingredientId)
        {
            var piDetail = _piService.Get_PreparedItemById(preparedItemId);
            if (!_piService.Delete_IngredientFromPreparedItem(piDetail, ingredientId))
                return InternalServerError();
            return Ok();
        }
    }
}
