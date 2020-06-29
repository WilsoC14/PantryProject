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

        [HttpPut]
        public IHttpActionResult Put_PreparedItemByName(PreparedItemEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_piService.Edit_PreparedItemByName(model)) 
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
        //public IHttpActionResult Get_AddIngredientToPreparedItemModel(string preparedItemName, string ingredientName, string ingredientState)
        //{
            
        //    var itemDetail = _piService.Get_PreparedItemByName(preparedItemName);
        //    var exists = _piService.IngredientInPreparedItemExists(itemDetail, ingredientName, ingredientState);
        //    if(!exists)
        //    {
        //        var model = new AddIngredientToPreparedItem()
        //        {
        //            IngredientName = ingredientName,
        //           // IngredientState = ingredientState,
        //            PreparedItemDetail = itemDetail
        //        };
            
        //    }

        //    return Ok();
        //}

        [HttpPost]
        [Route("AddIngredient")]// user would click a button with a PI.id attached to take them to a view to actually build the model to add the ingredient
        public IHttpActionResult Add_IngredientToPreparedItem(AddIngredientToPreparedItem model)
        {
            if (!_piService.Add_IngredientToPrepairedItem(model))
                return InternalServerError();
            return Ok(model);
        }

        [HttpDelete]
        [Route("RemoveIngredient")]
        public IHttpActionResult Delete_IngredientFromPreparedItem(string preparedItemName, string ingredientToDelete)
        {
            var piDetail = _piService.Get_PreparedItemByName(preparedItemName);
            if (!_piService.Delete_IngredientFromPreparedItem(piDetail, ingredientToDelete))
                return InternalServerError();
            piDetail = _piService.Get_PreparedItemByName(preparedItemName);
            return Ok(piDetail);
        }

        //private PreparedItem_Service Create_PreparedItemService()
        //{
        //    return new PreparedItem_Service();
        //}
    }
}
