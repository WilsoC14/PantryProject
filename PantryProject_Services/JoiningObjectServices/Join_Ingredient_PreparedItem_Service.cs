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
    public class Join_Ingredient_PreparedItem_Service
    {
        Join_Ingredient_PreparedItem_Service() { }

        // we already have a prepared Item, we are then creating a model that we can add an Ingredient to.
        // the model has the properties for the ingredient, but we are not giving them a value in this method
        public Add_Ingredient_To_PreparedItem_Model Get_AddIngredient_To_PreparedItem_Model(int PI_Id)
        {
           
            var PI_Service = new PreparedItem_Service();
            var PI_Detail = PI_Service.Get_PreparedItem_ById(PI_Id);
            return new Add_Ingredient_To_PreparedItem_Model()
            {
                PreparedItemId = PI_Detail.Id,
                PreparedItemName = PI_Detail.Name,
                ListOfIngredients = PI_Detail.ListOfIngredients
            };
        }

        public bool Create_Join_Ingredient_PreparedItem(Add_Ingredient_To_PreparedItem_Model model)
        {
            var entity = new Join_Ingredient_PreparedItem()
            {
                IngredientId = model.IngredientID,
                PreparedItemId = model.PreparedItemId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Join_Ingredient_PreparedItem_Table.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool Delete_Join_Ingredient_PreparedItem(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Join_Ingredient_PreparedItem_Table.Single(e => e.Id == id);
                ctx.Join_Ingredient_PreparedItem_Table.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
