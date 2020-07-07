using PantryProject.Models.Menu;
using PantryProject_Services.MainObjectServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PantryProject_API.Controllers
{
    public class MenuController : ApiController
    {
        private readonly MenuService _menuService = new MenuService();

        [HttpGet]
        public IHttpActionResult GetAllMenus()
        {
            return Ok(_menuService.GetAllMenus());
        }
        [HttpGet]
        public IHttpActionResult GetMenuById(int id)
        {
            return Ok(_menuService.GetMenuById(id));
        }
        [HttpPost]
        public IHttpActionResult CreateMenu(MenuCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_menuService.CreateMenu(model))
                return InternalServerError();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult PutMenu(MenuEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_menuService.EditMenu(model))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteMenu(int id)
        {
            if (!_menuService.DeleteMenu(id))
                return InternalServerError();
            return Ok();
        }

    }
}
