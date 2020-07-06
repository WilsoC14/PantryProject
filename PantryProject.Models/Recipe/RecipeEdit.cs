using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Models.Recipe
{
    public class RecipeEdit
    {
        public int Id { get; set; } // should probably be read only
        public string Name { get; set; }
    }
}
