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

        public bool Delete_Ingredient(int id)
        {
            var entity = Get_ActualIngredient_ById(id);

            using (var ctx = new ApplicationDbContext())
            {
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



