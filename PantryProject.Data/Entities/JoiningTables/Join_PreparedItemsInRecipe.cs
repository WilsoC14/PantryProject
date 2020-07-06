using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Data.Entities
{
    public class Join_PreparedItemsInRecipe
    {
        public int Id { get; set; }

        [ForeignKey(nameof(PreparedItem))]
        public int PreparedItemId { get; set; }
        public virtual PreparedItem PreparedItem { get; set; }

        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
