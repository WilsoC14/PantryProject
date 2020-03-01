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
        public bool Create_PreparedItem(PreparedItemCreate model)
        {
            PreparedItem entity = new PreparedItem()
            {
                Name = model.Name,
                TypeOf_PreparedItem = model.TypeOfPreparedItem,
                StateOf_PreparedItem = model.StateOfPreparedItem
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PreparedItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }             
        }

        public IEnumerable<PreparedItemListItem> Get_AllPreparedItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.PreparedItems
                               .Select(
                                   i => new PreparedItemListItem
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

        public PreparedItemDetail Get_PreparedItemByName(string itemName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PreparedItems.Single(i => i.Name == itemName);

                var item = new PreparedItemDetail()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    TypeOf_PreparedItem = entity.TypeOf_PreparedItem,
                    StateOf_PreparedItem = entity.StateOf_PreparedItem
                };
                return item;

            }
        }

        public PreparedItemDetail Get_PreparedItemById(int Id)
        {
            var ingService = new Ingredient_Service();
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PreparedItems.Single(i => i.Id == Id);
                var listOfIngredients = new List<IngredientListItem>()
                { };
                foreach(var ingredient in entity.Ingredients_In_PreparedItem)
                {
                    var ingredientDetail = ingService.Get_IngredientById(ingredient.Id);
                    var ingredientModel = new IngredientListItem()
                    {
                        Id = ingredient.Id,
                        Name = ingredientDetail.Name,

                    };
                    listOfIngredients.Add(ingredientModel);
                }
                var item = new PreparedItemDetail()
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

        public bool Edit_PreparedItemByName(PreparedItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PreparedItems.SingleOrDefault(i => i.Name == model.OriginalName);

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
                var entity = ctx.PreparedItems.SingleOrDefault(i => i.Name == name);

                ctx.PreparedItems.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }


        public bool Add_IngredientToPrepairedItem(AddIngredientToPreparedItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {   //if ingredient doesn't exist, we'll need to add it to the database
                var ingredientWithId = ctx.Ingredients.Single(i => i.Name == model.IngredientName);

                var entity = new Join_IngredientsInPreparedItem()
                {
                    PreparedItemId = model.PreparedItemId,
                    IngredientId = model.IngredientID
                };
                ctx.Join_IngredientsInPreparedItems.Add(entity);

                return ctx.SaveChanges() == 1;

            }
        }
        private PreparedItem Get_ActualPreparedItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PreparedItems
                        .Single(i => i.Id == id);
                return entity;
            }
            

        }

        

    }
}
