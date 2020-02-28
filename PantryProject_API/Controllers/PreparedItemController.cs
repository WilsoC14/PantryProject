﻿using PantryProject.Data.Entities;
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
            var preparedItem = pi_Service.Get_PreparedItem_ByName(name);
            return Ok(preparedItem);
        }

        [HttpGet]
        public IHttpActionResult Get_PreparedItemById(int id)
        {
            PreparedItem_Service pi_Service = Create_PreparedItemService();
            var preparedItem = pi_Service.Get_PreparedItem_ById(id);
            return Ok(preparedItem);
        }

        [HttpPut]
        public IHttpActionResult Put_PreparedItemByName(PreparedItem_Edit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PreparedItem_Service pi_Service = Create_PreparedItemService();


            if (!pi_Service.Edit_PreparedItemByName(model))
                return InternalServerError();
            return Ok();

        }

        [HttpPost]

        public IHttpActionResult Post_CreatePreparedItem(PreparedItem_Create model)
        { // put in some logic to prevent duplicate ingredient to be created.
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           
            PreparedItem_Service pi_Service = Create_PreparedItemService();

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

        [HttpPost] // user would click a button with a PI.id attached to take them to a view to actually build the model to add the ingredient
        public IHttpActionResult Add_IngredientToPreparedItem(Add_Ingredient_To_PreparedItem_Model model)
        {
            PreparedItem_Service pi_Service = Create_PreparedItemService();
            if (!pi_Service.Add_IngredientTo_PrepairedItem(model))
                return InternalServerError();
            return Ok(model);
        }
        private PreparedItem_Service Create_PreparedItemService()
        {
            return new PreparedItem_Service();
        }
    }
}
