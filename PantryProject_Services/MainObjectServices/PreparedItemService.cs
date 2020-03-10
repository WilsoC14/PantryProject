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
                TypeOfPreparedItem = model.TypeOfPreparedItem,
                StateOfPreparedItem = model.StateOfPreparedItem
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
                                       TypeOf_PreparedItem = i.TypeOfPreparedItem,
                                       StateOf_PreparedItem = i.StateOfPreparedItem
                                   }
                                   );
                return query.ToList();
            }
        }

        public PreparedItemDetail Get_PreparedItemByName(string itemName)
        {
            var ingredientService = new Ingredient_Service();
            using (var ctx = new ApplicationDbContext())
            {   // get prepared item by id, will need a trycatch if query returns null
                var entity = ctx.PreparedItems.Single(i => i.Name == itemName);
                // creates empty list to populate with ingredients.
                var listOfIngredients = new List<IngredientListItem>()
                { };
                foreach (var ingredient in entity.Ingredients)
                {
                    var ingredientModel = new IngredientListItem()
                    {
                        Id = ingredient.ActualIngredient.Id,
                        Name = ingredient.ActualIngredient.Name,
                        TypeOfIngredient = ingredient.ActualIngredient.TypeOfIngredient,
                        IngredientState = ingredient.ActualIngredient.IngredientState,
                    };
                    listOfIngredients.Add(ingredientModel);
                }
                var item = new PreparedItemDetail()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    TypeOf_PreparedItem = entity.TypeOfPreparedItem,
                    StateOf_PreparedItem = entity.StateOfPreparedItem,
                    ListOfIngredients = listOfIngredients
                };
                return item;
            }
    
        }

        public PreparedItemDetail Get_PreparedItemById(int Id)
        {
            //var ingredientService = new Ingredient_Service();
            using (var ctx = new ApplicationDbContext())                
            {   // get prepared item by id, will need a trycatch if query returns null
                var entity = ctx.PreparedItems.Single(i => i.Id == Id);
                // creates empty list to populate with ingredients.
                var listOfIngredients = new List<IngredientListItem>()
                { };
                foreach(var ingredient in entity.Ingredients)
                {
                    var ingredientModel = new IngredientListItem()
                    {
                        Id = ingredient.ActualIngredient.Id,
                        Name = ingredient.ActualIngredient.Name,
                        TypeOfIngredient = ingredient.ActualIngredient.TypeOfIngredient,
                        IngredientState = ingredient.ActualIngredient.IngredientState,                                
                    };
                    listOfIngredients.Add(ingredientModel);
                }
                var item = new PreparedItemDetail()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    TypeOf_PreparedItem = entity.TypeOfPreparedItem,
                    StateOf_PreparedItem = entity.StateOfPreparedItem,
                    ListOfIngredients = listOfIngredients
                };
                return item;
            }
        }

        public bool PreparedItemExists(string itemName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.PreparedItems.Any(i => i.Name == itemName);
            }
        }
        public bool IngredientInPreparedItemExists(PreparedItemDetail item, string ingredientToAdd, string ingredientToAddState)
        {
            

            foreach(var ingredient in item.ListOfIngredients)
            {
                PantryProject.Data.StateOfIngredient ingredientToAddStateAsEnum;
                Enum.TryParse(ingredientToAddState, true, out ingredientToAddStateAsEnum);
                
                if (ingredient.Name == ingredientToAdd && ingredient.IngredientState == ingredientToAddStateAsEnum)
                    return true;
                
            }
                return false;
        }
        public bool Edit_PreparedItemByName(PreparedItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PreparedItems.SingleOrDefault(i => i.Name == model.OriginalName);

                entity.Name = model.NewName;
                entity.TypeOfPreparedItem = model.TypeOf_PreparedItem;
                entity.StateOfPreparedItem = model.StateOf_PreparedItem;

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
                    IngredientId = ingredientWithId.Id
                };
                ctx.Join_IngredientsInPreparedItems.Add(entity);

                return ctx.SaveChanges() == 1;

            }
        }

        public bool Delete_IngredientFromPreparedItem(PreparedItemDetail item, string ingredientToDelete)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Join_IngredientsInPreparedItems
                                .Single(i => i.PreparedItemId == item.Id && i.ActualIngredient.Name == ingredientToDelete);
                ctx.Join_IngredientsInPreparedItems.Remove(entity);

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
