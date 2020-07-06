using PantryProject.Models.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Models.Menu
{
    public class MenuDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RecipeListItem> Recipes { get; set; }
    }
}
