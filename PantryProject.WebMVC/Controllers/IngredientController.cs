using PantryProject.Models.Ingredient;
using PantryProject_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PantryProject.WebMVC.Controllers
{
    public class IngredientController : Controller
    {
        // GET: Ingredient
        public ActionResult IngredientIndex()
        {
            var service = CreateIngredientService();
            var listOfIngredients = service.GetAll_Ingredients();
            return View(listOfIngredients);
        }
        // Get: Create Ingredient
        public ActionResult CreateIngredient() 
        {
             var service = CreateIngredientService();
            ViewBag.IngredientsList = service.GetAll_Ingredients();
            return View();
        }

        // Post: Create Ingredient
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateIngredient(IngredientCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateIngredientService();

            if (service.Create_Ingredient(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }



        private IngredientService CreateIngredientService()
        {
            return new IngredientService();
        }
    }
}