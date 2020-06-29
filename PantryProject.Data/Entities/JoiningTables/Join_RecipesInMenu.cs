using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Data.Entities
{
   public class Join_RecipesInMenu
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Indv_Recipe))]
        public int RecipeId { get; set; }
        public virtual Recipe Indv_Recipe { get; set; }

        [ForeignKey(nameof(Indv_Menu))]
        public int MenuId { get; set; }
        public virtual Menu Indv_Menu { get; set; }
    }
}
