using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Data.Entities
{
   public class Join_IngredientsInRecipe
    {[Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Indv_Ingredient))]
        public int IngredientId { get; set; }
        public virtual Ingredient Indv_Ingredient { get; set; }

        [ForeignKey(nameof(Indv_Recipe))]
        public int RecipeId { get; set; }
        public virtual Recipe Indv_Recipe { get; set; }
    }
}
