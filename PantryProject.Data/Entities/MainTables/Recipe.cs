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
        public virtual ICollection<Join_Ingredient_Recipe> Ingredients_In_Recipe { get; set; }
        public virtual ICollection<Join_PreparedItem_Recipe> PreparedItems_In_Recipe { get; set; }
        public virtual ICollection<Join_Recipe_Menu> Menus_With_Recipe { get; set; }
    }
}
