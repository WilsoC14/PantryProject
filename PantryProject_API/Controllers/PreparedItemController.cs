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
        [HttpGet]
        public IHttpActionResult GetAll_PreparedItems()
        {
            PreparedItem_Service pi_Service = Create_PreparedItemService();
            var preparedItems = pi_Service.Get_AllPreparedItems();
            return Ok(preparedItems);   //what is exactly happening when you pass the list into the Ok() 
        }

        [HttpGet]
        public IHttpActionResult Get_PreparedItemByName(string name)
        {
            PreparedItem_Service pi_Service = Create_PreparedItemService();
            var preparedItem = pi_Service.Get_PreparedItemByName(name);
            return Ok(preparedItem);
        }

        [HttpGet]
        public IHttpActionResult Get_PreparedItemById(int id)
        {
            PreparedItem_Service pi_Service = Create_PreparedItemService();
            var preparedItem = pi_Service.Get_PreparedItemById(id);
            return Ok(preparedItem);
        }

        [HttpPut]
        public IHttpActionResult Put_PreparedItemByName(PreparedItemEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PreparedItem_Service pi_Service = Create_PreparedItemService();


            if (!pi_Service.Edit_PreparedItemByName(model))
                return InternalServerError();
            return Ok();

        }

        [HttpPost]

        public IHttpActionResult Post_CreatePreparedItem(PreparedItemCreate model)
        { // put in some logic to prevent duplicate ingredient to be created.
            PreparedItem_Service pi_Service = Create_PreparedItemService();
            if (pi_Service.PreparedItemExists(model.Name))
            {
                return BadRequest("Item Already Exists");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (!pi_Service.Create_PreparedItem(model))
                return InternalServerError();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete_PreparedItemByName(string name)
        {
            PreparedItem_Service pi_Service = Create_PreparedItemService();
            if (!pi_Service.Delete_PreparedItemByName(name))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Get_AddIngredientToPreparedItemModel(string preparedItemName, string ingredientName, string ingredientState)
        {
            PreparedItem_Service pi_Service = Create_PreparedItemService();
            var itemDetail = pi_Service.Get_PreparedItemByName(preparedItemName);
            var exists = pi_Service.IngredientInPreparedItemExists(itemDetail, ingredientName, ingredientState);
            if(!exists)
            {
                var model = new AddIngredientToPreparedItem()
                {
                    IngredientName = ingredientName,
                   // IngredientState = ingredientState,
                    PreparedItemDetail = itemDetail
                };
            
            }

            return Ok();
        }

        [HttpPost]
        [Route("AddIngredient")]// user would click a button with a PI.id attached to take them to a view to actually build the model to add the ingredient
        public IHttpActionResult Add_IngredientToPreparedItem(AddIngredientToPreparedItem model)
        {
            PreparedItem_Service pi_Service = Create_PreparedItemService();
            if (!pi_Service.Add_IngredientToPrepairedItem(model))
                return InternalServerError();
            return Ok(model);
        }

        [HttpDelete]
        [Route("RemoveIngredient")]
        public IHttpActionResult Delete_IngredientFromPreparedItem(string preparedItemName, string ingredientToDelete)
        {
            PreparedItem_Service pi_Service = Create_PreparedItemService();
            var piDetail = pi_Service.Get_PreparedItemByName(preparedItemName);
            if (!pi_Service.Delete_IngredientFromPreparedItem(piDetail, ingredientToDelete))
                return InternalServerError();
            piDetail = pi_Service.Get_PreparedItemByName(preparedItemName);
            return Ok(piDetail);
        }

        private PreparedItem_Service Create_PreparedItemService()
        {
            return new PreparedItem_Service();
        }
    }
}
