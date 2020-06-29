using PantryProject.Data;
using PantryProject.Models.Ingredient;
using PantryProject_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject_Services
{
    public class IngredientService
    {
        public IngredientService() { }

        public bool Create_Ingredient(IngredientCreate ingredientToCreate)
        {
            Ingredient entity = new Ingredient()
            {
                Name = ingredientToCreate.Name,
                TypeOfIngredient = ingredientToCreate.TypeOfIngredient
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<IngredientListItem> GetAll_Ingredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ingredients
                               .Select(
                                   i => new IngredientListItem
                                   {
                                       Id = i.Id,
                                       Name = i.Name,
                                       TypeOfIngredient = i.TypeOfIngredient,
                                       IngredientState = i.IngredientState
                                   }
                                   );
                return query.ToList();
            }
        }

        public IngredientDetail Get_IngredientByName(string ingredientName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ingredients.Single(i => i.Name == ingredientName);

                var ingredient = new IngredientDetail()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    TypeOfIngredient = entity.TypeOfIngredient,
                    IngredientState = entity.IngredientState
                };
                return ingredient;

            }
        }

        public bool IngredientExists(string ingredientName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Ingredients.Any(i => i.Name == ingredientName);
            }
        }
        public IngredientDetail Get_IngredientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ingredients.Single(i => i.Id == id);

                var ingredient = new IngredientDetail()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    TypeOfIngredient = entity.TypeOfIngredient,
                    IngredientState = entity.IngredientState
                };
                return ingredient;
            }
        }

        public bool Edit_IngredientById(IngredientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ingredients.SingleOrDefault(i => i.Id == model.Id);

                entity.Name = model.NewName;
                entity.TypeOfIngredient = model.TypeOfIngredient;
                entity.IngredientState = model.IngredientState;

                if (!ctx.ChangeTracker.HasChanges())
                {
                    return true;
                }
                return ctx.SaveChanges() == 1;
            }

        }

        public bool Edit_IngredientByName(IngredientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ingredients.SingleOrDefault(i => i.Name == model.OriginalName);

                entity.Name = model.NewName;
                entity.TypeOfIngredient = model.TypeOfIngredient;
                entity.IngredientState = model.IngredientState;

                if (!ctx.ChangeTracker.HasChanges())
                {
                    return true;
                }
                return ctx.SaveChanges() == 1;
            }

        }

        public bool Delete_IngredientByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ingredients.SingleOrDefault(i => i.Name == name);

                ctx.Ingredients.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        private Ingredient Get_ActualIngredient_ById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredients
                        .Single(i => i.Id == id);
                return entity;
            }


        }

    }
}



