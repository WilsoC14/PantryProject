using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Data.Entities
{
    public enum PreparedItemType { unclassified, puree, sauce, paste, blend, liquid, other }
    public enum PreparedItemState { liquid, solid, gas }
    public class PreparedItem
    {[Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public PreparedItemType TypeOf_PreparedItem { get; set; }
        [Required]
        public PreparedItemState StateOf_PreparedItem { get; set; }
        public virtual ICollection<Join_IngredientsInPreparedItem> Ingredients_In_PreparedItem { get; set; }
        public virtual ICollection<Join_PreparedItemsInRecipe> Recipes_With_PreparedItem { get; set; }
    }
}
