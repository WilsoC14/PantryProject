using PantryProject.Data.Entities;
using PantryProject.Models.Ingredient;
using PantryProject.Models.JoiningModels;
using PantryProject.Models.PreparedItem;
using PantryProject_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject_Services
{
    public class PreparedItem_Service
    {
       public PreparedItem_Service() { }
        public bool Create_PreparedItem(PreparedItem_Create model)
        {
            PreparedItem entity = new PreparedItem()
            {
                Name = model.Name,
                TypeOf_PreparedItem = model.TypeOf_PreparedItem,
                StateOf_PreparedItem = model.StateOf_PreparedItem
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PreparedItem_Table.Add(entity);
                return ctx.SaveChanges() == 1;
            }             
        }

        public IEnumerable<PreparedItem_ListItem> Get_AllPreparedItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.PreparedItem_Table
                               .Select(
                                   i => new PreparedItem_ListItem
                                   {
                                       Id = i.Id,
                                       Name = i.Name,
                                       TypeOf_PreparedItem = i.TypeOf_PreparedItem,
                                       StateOf_PreparedItem = i.StateOf_PreparedItem
                                   }
                                   );
                return query.ToList();
            }
        }

        public PreparedItem_Detail Get_PreparedItem_ByName(string itemName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PreparedItem_Table.Single(i => i.Name == itemName);

                var item = new PreparedItem_Detail()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    TypeOf_PreparedItem = entity.TypeOf_PreparedItem,
                    StateOf_PreparedItem = entity.StateOf_PreparedItem
                };
                return item;

            }
        }

        public PreparedItem_Detail Get_PreparedItem_ById(int Id)
        {
            var ingService = new Ingredient_Service();
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PreparedItem_Table.Single(i => i.Id == Id);
                var listOfIngredients = new List<Ingredient_ListItem>()
                { };
                foreach(var ingredient in entity.Ingredients_In_PreparedItem)
                {
                    var ingredientDetail = ingService.Get_IngredientById(ingredient.Id);
                    var ingredientModel = new Ingredient_ListItem()
                    {
                        Id = ingredient.Id,
                        Name = ingredientDetail.Name,

                    };
                    listOfIngredients.Add(ingredientModel);
                }
                var item = new PreparedItem_Detail()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    TypeOf_PreparedItem = entity.TypeOf_PreparedItem,
                    StateOf_PreparedItem = entity.StateOf_PreparedItem,
                    ListOfIngredients = listOfIngredients
                };
                return item;

            }
        }

        public bool Edit_PreparedItemByName(PreparedItem_Edit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PreparedItem_Table.SingleOrDefault(i => i.Name == model.OriginalName);

                entity.Name = model.NewName;
                entity.TypeOf_PreparedItem = model.TypeOf_PreparedItem;
                entity.StateOf_PreparedItem = model.StateOf_PreparedItem;

                if (!ctx.ChangeTracker.HasChanges())
                {
                    return true;
                }
                return ctx.SaveChanges() == 1;
            }

        }
        public bool Delete_PreparedItemByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PreparedItem_Table.SingleOrDefault(i => i.Name == name);

                ctx.PreparedItem_Table.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }


        public bool Add_IngredientTo_PrepairedItem(Add_Ingredient_To_PreparedItem_Model model)
        {
            using (var ctx = new ApplicationDbContext())
            {   //if ingredient doesn't exist, we'll need to add it to the database
                var ingredientWithId = ctx.Ingredient_Table.Single(i => i.Name == model.IngredientName);

                var entity = new Join_Ingredient_PreparedItem()
                {
                    PreparedItemId = model.PreparedItemId,
                    IngredientId = model.IngredientID
                };
                ctx.Join_Ingredient_PreparedItem_Table.Add(entity);

                return ctx.SaveChanges() == 1;

            }
        }
        private PreparedItem Get_ActualPreparedItem_ById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PreparedItem_Table
                        .Single(i => i.Id == id);
                return entity;
            }
            

        }

        

    }
}
