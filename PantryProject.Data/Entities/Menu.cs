using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Data.Entities
{ 
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RecipeInMenu> Recipes_In_Menu { get; set; }
        
    }
    
}
