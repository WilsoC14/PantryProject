using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Data.Entities
{
    public class Join_IngredientsInPreparedItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Indv_Ingredient))]
        public int IngredientId { get; set; }
        public virtual Ingredient Indv_Ingredient { get; set; }
        [Required]
        [ForeignKey(nameof(Indv_PreparedItem))]
        public int PreparedItemId { get; set; }
        public virtual PreparedItem Indv_PreparedItem { get; set; }
    }
}
