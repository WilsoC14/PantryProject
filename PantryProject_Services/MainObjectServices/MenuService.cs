using PantryProject.Data.Entities;
using PantryProject.Models.Menu;
using PantryProject.Models.Recipe;
using PantryProject_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject_Services.MainObjectServices
{
    public class MenuService
    {
        public bool CreateMenu(MenuCreate model)
        {
            Menu entity = new Menu()
            {
                Name = model.Name,          
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Menus.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MenuListItem> GetAllMenus()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.PreparedItems
                               .Select(
                                   i => new MenuListItem
                                   {
                                       Id = i.Id,
                                       Name = i.Name,    
                                   }
                                   );
                return query.ToList();
            }
        }
        public MenuDetail GetMenuById(int id)
        {
            var listOfRecipes = new List<RecipeListItem>();

            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Menus.SingleOrDefault(m => m.Id == id);
                foreach(var recipe in entity.Recipes_In_Menu)
                {
                    var recipeModel = new RecipeListItem()
                    {
                        Id = recipe.RecipeId,
                        Name = recipe.Recipe.Name
                    };
                    listOfRecipes.Add(recipeModel);
                }
                return new MenuDetail()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Recipes = listOfRecipes
                };
            }
        }

        public bool EditMenu(MenuEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Menus.SingleOrDefault(m => m.Id == model.Id);
                entity.Name = model.Name;
                if (!ctx.ChangeTracker.HasChanges())
                {
                    return true;
                }
                return ctx.SaveChanges() == 1;


            }
        }

        public bool DeleteMenu(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Menus.SingleOrDefault(i => i.Id == id);

                ctx.Menus.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
