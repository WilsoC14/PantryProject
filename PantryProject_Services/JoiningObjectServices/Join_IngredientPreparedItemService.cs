using PantryProject.Data.Entities;
using PantryProject.Models.JoiningModels;
using PantryProject_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject_Services.JoiningObjectServices
{
    public class Join_IngredientPreparedItemService
    {
        Join_IngredientPreparedItemService() { }

        // we already have a prepared Item, we are then creating a model that we can add an Ingredient to.
        // the model has the properties for the ingredient, but we are not giving them a value in this method
        // this method probably will only be used to populate views for the WebPages assembly
        public AddIngredientToPreparedItem Get_AddIngredientToPreparedItem(int PI_Id, int ingredientId)
        {
           
            var PI_Service = new PreparedItem_Service();
            var PI_Detail = PI_Service.Get_PreparedItemById(PI_Id);
            return new AddIngredientToPreparedItem()
            {
                //PreparedItemDetail = PI_Detail,
                IngredientId = ingredientId
            };
        }

        public bool Create_JoinIngredientPreparedItem(AddIngredientToPreparedItem model)
        {
            var entity = new Join_IngredientsInPreparedItem()
            {
                IngredientId = model.IngredientId,
                PreparedItemId = model.PreparedItemId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Join_IngredientsInPreparedItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool Delete_JoinIngredientPreparedItem(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Join_IngredientsInPreparedItems.Single(e => e.Id == id);
                ctx.Join_IngredientsInPreparedItems.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
