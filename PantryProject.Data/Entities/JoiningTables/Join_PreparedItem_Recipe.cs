using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Data.Entities
{
    public class Join_PreparedItem_Recipe
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Indv_PreparedItem))]
        public int PreparedItemId { get; set; }
        public virtual PreparedItem Indv_PreparedItem { get; set; }

        [ForeignKey(nameof(Indv_Recipe))]
        public int RecipeId { get; set; }
        public virtual Recipe Indv_Recipe { get; set; }
    }
}
