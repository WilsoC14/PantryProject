using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Data.Entities
{
   public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Join_IngredientsInRecipe> Ingredients { get; set; }
        public virtual ICollection<Join_PreparedItemsInRecipe> PreparedItems { get; set; }
        public virtual ICollection<Join_RecipesInMenu> Menus { get; set; }
    }
}
