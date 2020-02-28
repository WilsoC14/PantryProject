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

        public bool Create_Ingredient(Ingredient_Create ingredientToCreate)
        {
            Ingredient entity = new Ingredient()
            {
                Name = ingredientToCreate.Name,
                TypeOfIngredient = ingredientToCreate.TypeOfIngredient
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredient_Table.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<Ingredient_ListItem> Get_AllIngredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ingredient_Table
                               .Select(
                                   i => new Ingredient_ListItem
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

        public Ingredient_Detail Get_IngredientByName(string ingredientName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ingredient_Table.Single(i => i.Name == ingredientName);

                var ingredient = new Ingredient_Detail()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    TypeOfIngredient = entity.TypeOfIngredient,
                    IngredientState = entity.IngredientState
                };
                return ingredient;

            }
        }

        public Ingredient_Detail Get_IngredientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ingredient_Table.Single(i => i.Id == id);

                var ingredient = new Ingredient_Detail()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    TypeOfIngredient = entity.TypeOfIngredient,
                    IngredientState = entity.IngredientState
                };
                return ingredient;
            }
        }

        public bool Edit_IngredientById(Ingredient_Edit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ingredient_Table.SingleOrDefault(i => i.Id == model.Id);

                entity.Name = model.NewName;
                entity.TypeOfIngredient = model.TypeOfIngredient;
                entity.IngredientState = model.IngredientState;

                if(!ctx.ChangeTracker.HasChanges())
                {
                    return true;
                }
                return ctx.SaveChanges() == 1;
            }

        }

        public bool Edit_IngredientByName(Ingredient_Edit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ingredient_Table.SingleOrDefault(i => i.Name == model.OldName);

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
                var entity = ctx.Ingredient_Table.SingleOrDefault(i => i.Name == name);

                ctx.Ingredient_Table.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        private Ingredient Get_ActualIngredient_ById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredient_Table
                        .Single(i => i.Id == id);
                return entity;
            }


        }

    }
}



