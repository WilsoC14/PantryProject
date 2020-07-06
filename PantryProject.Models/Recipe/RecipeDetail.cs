
using PantryProject.Models.Ingredient;
using PantryProject.Models.Menu;
using PantryProject.Models.PreparedItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Models.Recipe
{
    public class RecipeDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IngredientListItem> Ingredients { get; set; }
        public List<PreparedItemListItem> PreparedItems { get; set; }
        public List<MenuListItem> Menus { get; set; }
    }
}
