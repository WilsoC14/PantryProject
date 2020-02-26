using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Data.Entities
{
    public enum PreparedItem_Type { sauce, paste, blend, liquid, other }
    public enum PreparedItem_State { liquid, solid, gas }
    public class PreparedItem
    {[Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public PreparedItem_Type TypeOf_PreparedItem { get; set; }
        [Required]
        public PreparedItem_State StateOf_PreparedItem { get; set; }
        public virtual ICollection<Join_Ingredient_PreparedItem> Ingredients_In_PreparedItem { get; set; }
        public virtual ICollection<Join_PreparedItem_Recipe> Recipes_With_PreparedItem { get; set; }
    }
}
